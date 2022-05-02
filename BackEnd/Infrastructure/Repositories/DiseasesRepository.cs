using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using BackEnd.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using BackEnd.Domain.Queries;
using BackEnd.Domain.DTOs;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Repositories
{
    public class DiseasesRepository : IDiseasesRepository
    {
        StoreDataContext _context;

        public DiseasesRepository(StoreDataContext context) =>
            _context = context;

        public async Task<bool> Create(Diseases diseases)
        {
            try
            {
                await _context.Diseases.InsertOneAsync(diseases);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<SimpleDiseasesDTO>> GetAll()
        {
            var result = await _context.Diseases.Find(x => true).ToListAsync();

            List<SimpleDiseasesDTO> diseases;
            MoutDiseaseDTO(result, out diseases);

            return diseases;
        }

        public async Task<CompleteDiseasesDTO> GetById(string id)
        {
            var result = await _context.Diseases.Find(DiseasesQuery.GetById(id)).SingleOrDefaultAsync();

            CompleteDiseasesDTO disease;
            MoutDiseaseDTO(result, out disease);

            return disease;
        }

        public async Task<IEnumerable<SimpleDiseasesDTO>> GetDiseasesBySymptoms(IEnumerable<SymptomsDTO> symptoms)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Update(Diseases diseases)
        {
            try
            {
                await _context.Diseases.ReplaceOneAsync(x => x.Id == diseases.Id, diseases);
                return true;
            }
            catch
            {
                return false;
            }
        }

        void MoutDiseaseDTO(List<Diseases> diseases, out List<SimpleDiseasesDTO> diseasesOut)
        {
            diseasesOut = new List<SimpleDiseasesDTO>();
            
            foreach (var disease in diseases)
            {
                SimpleDiseasesDTO diseaseOut = new SimpleDiseasesDTO
                {
                    Name = disease.Name,
                    Id = disease.Id
                };
                diseasesOut.Add(diseaseOut);
            }
        }

        void MoutDiseaseDTO(Diseases disease, out CompleteDiseasesDTO diseaseOut)
        {
            List<SymptomDataDTO> symptoms;
            RecoverSymptom(disease, out symptoms);
            
            diseaseOut = new CompleteDiseasesDTO
            {
                Id = disease.Id,
                Name = disease.Name,
                Symptom = symptoms
            };
        }

        void RecoverSymptom(Diseases disease, out List<SymptomDataDTO> symptoms)
        {
            symptoms = new List<SymptomDataDTO>();

            foreach (var id in disease.Symptoms)
            {
                Symptoms symptom;
                RecoverSymptomDb(id, out symptom);
                if (symptom != null)
                    symptoms.Add(new SymptomDataDTO
                    {
                        Id = symptom.Id,
                        Name = symptom.Name,
                    });
            }
        }


        void RecoverSymptomDb(string id, out Symptoms symptom) =>
            symptom = _context.Symptoms.Find(SymptomQuery.GetById(id)).SingleOrDefault();
    
    }
}
