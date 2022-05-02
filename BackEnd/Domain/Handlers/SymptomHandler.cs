using BackEnd.Domain.Commands;
using BackEnd.Domain.Commands.Contracts;
using BackEnd.Domain.Entities;
using BackEnd.Domain.Handlers.Contracts;
using BackEnd.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace BackEnd.Domain.Handlers
{
    public class SymptomHandler :
        IHandler<CreateSymptomsCommand>,
        IHandler<UpdateSymptomsCommand>
    {
        ISymptomRepository _repository;
        ILogger<SymptomHandler> _logger;

        public SymptomHandler(ISymptomRepository repository, ILogger<SymptomHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public ICommandResult Handle(CreateSymptomsCommand request)
        {
            _logger.LogInformation("Starting the data manipulation process of a new symptom");

            // fast validation
            request.Validate();
            if (!request.IsValid)
            {
                _logger.LogError($"Could not continue with the operation, the following incorrect data was passed:  {request.Notifications.ToString()}");
                return new ResultCommand
                {
                    Message = "Could not continue with the operation",
                    Data = request.Notifications,
                    HasError = true
                };
            }
            
            // create entity
            var symptom = new Symptoms(request.Name);

            // save in the repository
            if (_repository.Create(symptom).Result)
            {
                _logger.LogInformation("A new symptom has been successfully registered");
                return new ResultCommand
                {
                    Message = "A new symptom was successfully registered",
                    Data = symptom,
                    HasError = false
                };
            }

            _logger.LogError("Could not continue with the operation, error was presented when saving to the repository");

            // displays message in case of error when saving to repository
            return new ResultCommand
            {
                Message = "Could not continue with the operation",
                Data = "Error was presented when saving to the repository",
                HasError = true
            };
        }

        public ICommandResult Handle(UpdateSymptomsCommand request)
        {
            _logger.LogInformation("Starting the data manipulation process to change an existing symptom");

            // fast validation
            request.Validate();
            if (!request.IsValid)
            {
                _logger.LogError($"Could not continue with the operation, the following incorrect data was passed:  {request.Notifications.ToString()}");
                return new ResultCommand
                {
                    Message = "Could not continue with the operation",
                    Data = request.Notifications,
                    HasError = true
                };
            }
                

            // try to get the symptoms from the repository
            var symptom = _repository.GetById(request.Id).Result;

            // displays an error message if it cannot find the symptoms in the repository
            if(symptom == null)
            {
                _logger.LogError($"Could not continue with the operation, this symptom was not found");
                return new ResultCommand
                {
                    Message = "Could not continue with the operation",
                    Data = "This symptom was not found",
                    HasError = true
                };
            }
                

            // Update symptom name
            symptom.Update(request.Name);

            // Update the symptom in the repository
            if (_repository.Update(symptom).Result)
            {
                _logger.LogInformation("Symptom data has been updated successfully");
                return new ResultCommand
                {
                    Message = "Symptom data has been updated successfully",
                    Data = symptom,
                    HasError = false
                };
            }

            _logger.LogError("Could not continue with the operation, error was presented when saving to the repository");

            // displays message in case of error when saving to repository
            return new ResultCommand
            {
                Message = "Could not continue with the operation",
                Data = "Error was presented when saving to the repository",
                HasError = true
            };
        }
    }
}
