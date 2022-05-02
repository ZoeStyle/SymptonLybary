using BackEnd.Domain.Commands.Contracts;
using BackEnd.Domain.DTOs;
using Flunt.Notifications;
using Flunt.Validations;
using System.Collections.Generic;

namespace BackEnd.Domain.Commands
{
    public class CreateDiseasesCommand : Notifiable<Notification>, ICommand
    {
        public CreateDiseasesCommand()
        { }

        public CreateDiseasesCommand(string name, List<SymptomsDTO> symptoms)
        {
            Name = name;
            Symptoms = symptoms;
        }

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
                .IsNotNullOrEmpty(Name,nameof(Name))
                .IsLowerThan(Name,60, nameof(Name))
                .IsGreaterThan(Symptoms,0,nameof(Symptoms))
                );
        }
    }
}
