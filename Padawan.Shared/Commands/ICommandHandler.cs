
using System.Threading.Tasks;

namespace Padawan.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}
