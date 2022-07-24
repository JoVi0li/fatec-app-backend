using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecAppBackend.Shared.Commands
{
    public class GenericCommandsResult : ICommandResult
    {
        public GenericCommandsResult(bool success, string message, Object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; private set; }

        public string Message { get; private set; }

        public Object Data { get; private set; }
    }
}
