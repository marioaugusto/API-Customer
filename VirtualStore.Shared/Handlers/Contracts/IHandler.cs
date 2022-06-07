

using VirtualStore.Shared.Commands.Contracts;

namespace VirtualStore.Shared.Handlers.Contracts;

public interface IHandler<T> where T: ICommand
{
    ICommandResult Handle(T command);


}