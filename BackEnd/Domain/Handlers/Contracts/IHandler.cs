using BackEnd.Domain.Commands.Contracts;

namespace BackEnd.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T request);
    }
}
