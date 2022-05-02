using BackEnd.Domain.DTOs;
using BackEnd.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Domain.Repositories
{
    public interface IDiseasesRepository
    {
        Task<bool> Create(Diseases diseases);
        Task<bool> Update(Diseases diseases);
        Task<IEnumerable<SimpleDiseasesDTO>> GetAll();
        Task<IEnumerable<SimpleDiseasesDTO>> GetDiseasesBySymptoms(IEnumerable<SymptomsDTO> symptoms);
        Task<CompleteDiseasesDTO> GetById(string id);
    }
}
