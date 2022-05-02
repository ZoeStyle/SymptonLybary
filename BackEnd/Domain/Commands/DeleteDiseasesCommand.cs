using BackEnd.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace BackEnd.Domain.Commands
{
    public class DeleteDiseasesCommand : Notifiable<Notification>, ICommand
    {
        public string Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<string>()
                .Requires()
                .IsNullOrEmpty(Id, nameof(Id))
                );
        }
    }
}
