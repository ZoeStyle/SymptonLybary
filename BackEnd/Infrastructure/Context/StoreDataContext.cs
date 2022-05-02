using BackEnd.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BackEnd.Infrastructure.Context
{
    public partial class StoreDataContext
    {
        public StoreDataContext(IConfiguration configuration)
        {
            var settings = MongoClientSettings.FromConnectionString(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var client = new MongoClient(settings);

            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Symptoms = database.GetCollection<Symptoms>(configuration.GetValue<string>("DatabaseSettings:CollectionSymptomName"));
            Diseases = database.GetCollection<Diseases>(configuration.GetValue<string>("DatabaseSettings:CollectionDiseaseName"));
        }

        public IMongoCollection<Symptoms> Symptoms { get; }
        public IMongoCollection<Diseases> Diseases { get; }

    }
}
