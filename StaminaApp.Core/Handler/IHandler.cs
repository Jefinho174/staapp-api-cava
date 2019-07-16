using StaminaApp.Core.Commands;

namespace StaminaApp.Core.Handler
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handler(T command);
    }
}