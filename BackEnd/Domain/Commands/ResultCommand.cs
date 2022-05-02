using BackEnd.Domain.Commands.Contracts;

namespace BackEnd.Domain.Commands
{
    public class ResultCommand : ICommandResult
    {
        public bool HasError { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ResultCommand()
        { }

        public ResultCommand(bool hasError, string message, object data)
        {
            HasError = hasError;
            Message = message;
            Data = data;
        }
    }
}
