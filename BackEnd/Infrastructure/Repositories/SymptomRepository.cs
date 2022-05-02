using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using System.Collections.Generic;
using BackEnd.Infrastructure.Context;
using System.Threading.Tasks;
using MongoDB.Driver;
using BackEnd.Domain.Queries;

namespace BackEnd.Infrastructure.Repositories
{
    public class SymptomRepository : ISymptomRepository
    {
        StoreDataContext _context;

        public SymptomRepository(StoreDataContext context) =>
            _context = context;

        public async Task<bool> Create(Symptoms symptom)
        {
            try
            {
                await _context.Symptoms.InsertOneAsync(symptom);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Symptoms>> GetAll() =>
            await _context.Symptoms.Find(x => true).ToListAsync();

        public async Task<Symptoms> GetById(string id)=>
            await _context.Symptoms.Find(SymptomQuery.GetById(id)).SingleOrDefaultAsync();

        public async Task<Symptoms> GetByName(string name) =>
             await _context.Symptoms.Find(SymptomQuery.GetByName(name)).SingleOrDefaultAsync();

        public async Task<bool> Update(Symptoms symptom)
        {
            try
            {
                await _context.Symptoms.ReplaceOneAsync(x => x.Id == symptom.Id, symptom);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
