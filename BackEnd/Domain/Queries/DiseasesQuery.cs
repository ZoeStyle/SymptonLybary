using BackEnd.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BackEnd.Domain.Queries
{
    public static class DiseasesQuery
    {
        public static Expression<Func<Diseases, bool>> GetById(string id) =>
            x => x.Id == id;

        //public static Expression<Func<Diseases, bool>> GetBySymptoms(Symptoms symptom) =>
        //    x => x.SymptomsList.Contains(symptom);
    }
}
