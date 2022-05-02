using System;

namespace BackEnd.Domain.Entities
{
    public abstract class Entity
    {
        public Entity() =>
            Id = Guid.NewGuid().ToString().Replace("-","").Substring(0,10);

        public string Id { get; private set; }
    }
}
