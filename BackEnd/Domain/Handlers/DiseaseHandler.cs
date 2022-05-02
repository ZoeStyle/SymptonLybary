using BackEnd.Domain.Commands;
using BackEnd.Domain.Commands.Contracts;
using BackEnd.Domain.DTOs;
using BackEnd.Domain.Entities;
using BackEnd.Domain.Handlers.Contracts;
using BackEnd.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BackEnd.Domain.Handlers
{
    public class DiseaseHandler :
        IHandler<CreateDiseasesCommand>,
        IHandler<UpdateDiseasesCommand>
    {
        IDiseasesRepository _DiseasesRepository;
        ISymptomRepository _symptomRepository;
        ILogger<DiseaseHandler> _logger;

        public DiseaseHandler(IDiseasesRepository diseasesRepository, ISymptomRepository symptomRepository, ILogger<DiseaseHandler> logger)
        {
            _DiseasesRepository = diseasesRepository;
            _symptomRepository = symptomRepository;
            _logger = logger;
        }

        public ICommandResult Handle(CreateDiseasesCommand request)
        {
            _logger.LogInformation("Starting the data manipulation process of a new disease");

            // fast validation
            request.Validate();
            if (!request.IsValid)
            {
                _logger.LogError($"Could not continue with the operation, the following incorrect data was passed: {request.Notifications.ToString()}");
                return new ResultCommand
                {
                    Message = "Could not continue with the operation",
                    Data = request.Notifications,
                    HasError = true
                };
            }

            // validate if you have a list of symptoms registered and return a list of id
            List<string> listSymptomsId;
            if (!ValidateListSymptom(request.Symptoms, out listSymptomsId))
            {
                _logger.LogError("Could not find all symptoms listed");
                return new ResultCommand
                {
                    Message = "Could not find all symptoms listed",
                    Data = request.Symptoms,
                    HasError = true
                };
            }    

            // create entity
            var disease = new Diseases(request.Name, listSymptomsId);

            // save in the repository
            if (_DiseasesRepository.Create(disease).Result)
            {
                _logger.LogInformation("A new disease has been successfully registered");
                return new ResultCommand
                {
                    Message = "A new disease has been successfully registered",
                    Data = disease,
                    HasError = false
                };
            }

            _logger.LogError($"Could not continue with the operation, error was presented when saving to the repository");

            // displays message in case of error when saving to repository
            return new ResultCommand
            {
                Message = "Could not continue with the operation",
                Data = "Error was presented when saving to the repository",
                HasError = false
            };
        }

        public ICommandResult Handle(UpdateDiseasesCommand request)
        {
            _logger.LogInformation("Starting the data manipulation process to change the existing disease");

            // fast validation
            request.Validate();
            if (!request.IsValid)
            {
                _logger.LogError($"Could not continue with the operation, the following incorrect data was passed: {request.Notifications.ToString()}");
                return new ResultCommand
                {
                    Message = "Could not continue with the operation",
                    Data = request.Notifications,
                    HasError = true
                };
            }

            // try to get diseases from the repository
            var diseaseDTO = _DiseasesRepository.GetById(request.Id).Result;

            // displays an error message if it cannot find the diseases in the repository
            if (diseaseDTO == null)
            {
                _logger.LogError($"Could not continue with the operation, this disease was not found");
                return new ResultCommand
                {
                    Message = "Could not continue with the operation",
                    Data = "This disease was not found",
                    HasError = true
                };
            }

            // validate if you have a list of symptoms registered and return a list of id
            List<string> listSymptomsId;
            if (!ValidateListSymptom(request.Symptoms, out listSymptomsId)) 
            {
                _logger.LogError("Could not find all symptoms listed");
                return new ResultCommand
                {
                    Message = "Could not find all symptoms listed",
                    Data = request.Symptoms,
                    HasError = true
                };
            }

            var disease = new Diseases(request.Name, listSymptomsId);

            // Update the disease in the repository
            if (_DiseasesRepository.Update(disease).Result)
            {
                _logger.LogInformation("Disease data has been updated successfully");
                return new ResultCommand
                {
                    Message = "Disease data has been updated successfully",
                    Data = disease,
                    HasError = false
                };
            }

            _logger.LogError($"Could not continue with the operation, error was presented when saving to the repository");

            // displays message in case of error when saving to repository
            return new ResultCommand
            {
                Message = "Could not continue with the operation",
                Data = "Error was presented when saving to the repository",
                HasError = true
            };
        }

        bool ValidateListSymptom(List<SymptomsDTO> symptomsDTOList, out List<string> listOut)
        {
            var symptomList = new List<Symptoms>();
            listOut = new List<string>();
            foreach (var symptomDTO in symptomsDTOList)
            {
                // try to get the symptoms from the repository
                var symptom = _symptomRepository.GetById(symptomDTO.Code).Result;

                // displays an error message if it cannot find the symptoms in the repository
                if (symptom != null)
                {
                    symptomList.Add(symptom);
                    listOut.Add(symptom.Id);
                }
            }

            if (symptomList.Count == symptomsDTOList.Count)
                return true;
            return false;
        }
    }
}