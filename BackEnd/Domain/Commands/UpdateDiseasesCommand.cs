using BackEnd.Domain.Commands.Contracts;
using BackEnd.Domain.DTOs;
using Flunt.Notifications;
using Flunt.Validations;
using System.Collections.Generic;

namespace BackEnd.Domain.Commands
{
    public class UpdateDiseasesCommand : Notifiable<Notification>, ICommand
    {
        public UpdateDiseasesCommand()
        { }

        public UpdateDiseasesCommand(string id, string name, List<SymptomsDTO> symptoms)
        {
            Id = id;
            Name = name;
            Symptoms = symptoms;
        }

        /// <summary>
        /// Id Disease
        /// </summary>
        /// <example>45as87rtha</example>
        public string Id { get; set; }

        /// <summary>
        /// Name Disease
        /// </summary>
        /// <example>Covid 19</example>
        public string Name { get; set; }

        /// <summary>
        /// Symptoms List
        /// </summary>
        public List<SymptomsDTO> Symptoms { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract<string>()
                .Requires()
                .IsNotNullOrEmpty(Id,nameof(Id))
                .IsNotNullOrEmpty(Name, nameof(Name))
                .IsLowerThan(Name, 60, nameof(Name))
                .IsGreaterThan(Symptoms, 0, nameof(Symptoms))
                );
        }
    }
}
