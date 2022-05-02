namespace BackEnd.Domain.Entities
{
    public class Symptoms : Entity
    {
        public string Name { get; private set; }

        public Symptoms(string name) =>
            Name = name;

        public void Update(string name) =>
            Name = name;

    }
}
