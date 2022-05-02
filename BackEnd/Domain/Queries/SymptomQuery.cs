using BackEnd.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace BackEnd.Domain.Queries
{
    public static class SymptomQuery
    {
        public static Expression<Func<Symptoms, bool>> GetById(string id) =>
            x => x.Id == id;

        public static Expression<Func<Symptoms, bool>> GetByName(string name) =>
            x => x.Name == name;
    }
}
