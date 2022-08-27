using FatecAppBackend.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Shared.Handlers.Contracts
{
    public interface IHandlerCommand<T> where T : ICommand
    {
        ICommandResult Execute(T command);
    }
}
