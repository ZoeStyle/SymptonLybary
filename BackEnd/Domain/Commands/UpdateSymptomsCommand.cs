using BackEnd.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BackEnd.Domain.Commands
{
    public class UpdateSymptomsCommand : Notifiable<Notification>, ICommand
    {
        public UpdateSymptomsCommand()
        { }

        public UpdateSymptomsCommand(string id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Id Disease
        /// </summary>
        /// <example>45as87rtha</example>
        public string Id { get; set; }

        /// <summary>
        /// Symptom Name
        /// </summary>
        /// <example>Cough</example>
        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<string>()
                .Requires()
                .IsNotNullOrEmpty(Id, nameof(Id))
                .IsNotNullOrEmpty(Name, nameof(Name))
                .IsLowerThan(Name, 60, nameof(Name))
                );
        }
    }
}
