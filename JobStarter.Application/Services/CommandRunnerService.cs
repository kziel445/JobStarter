using JobStarter.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStarter.Application.Services
{
    internal class CommandRunnerService
    {
        private readonly ICommandExecutor _commandExecutor;
        public CommandRunnerService(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }
        public void RunCommandsSequentially(List<string> commands)
        {
            foreach (var command in commands)
            {
                _commandExecutor.ExecuteCommand(command);
            }
        }
    }
}
