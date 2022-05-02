using System.Collections.Generic;

namespace BackEnd.Domain.Entities
{
    public class Diseases : Entity
    {
        public List<string> Symptoms { get; private set; }
        public string Name { get; private set; }
        
        public Diseases()
        { }

        public Diseases(string name, List<string> symptoms)
        {
            Name = name;
            Symptoms = symptoms;
        }
    }
}
