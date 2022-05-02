using BackEnd.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BackEnd.Domain.Commands
{
    public class CreateSymptomsCommand : Notifiable<Notification>, ICommand
    {
        public CreateSymptomsCommand()
        { }

        public CreateSymptomsCommand(string name) =>
            Name = name;

        /// <summary>
        /// Symptom Name
        /// </summary>
        /// <example>Cough</example>
        public string Name { get; set; }
        
        public void Validate()
        {
            AddNotifications(new Contract<string>()
                .Requires()
                .IsNotNullOrEmpty(Name, nameof(Name))
                .IsLowerThan(Name,60, nameof(Name))
                );
        }
    }
}
