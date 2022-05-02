using BackEnd.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Domain.Repositories
{
    public interface ISymptomRepository
    {
        Task<bool> Create(Symptoms symptom);
        Task<bool> Update(Symptoms symptom);
        Task<IEnumerable<Symptoms>> GetAll();
        Task<Symptoms> GetById(string id);
        Task<Symptoms> GetByName(string name);

    }
}
