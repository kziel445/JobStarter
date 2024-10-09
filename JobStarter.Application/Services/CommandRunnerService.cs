using JobStarter.Application.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JobStarter.Application.Services
{
    public class CommandRunnerService
    {
        private readonly ICommandExecutor _commandExecutor;
        public readonly ILogger<ICommandExecutor> _logger;
        public CommandRunnerService(ICommandExecutor commandExecutor, ILogger<ICommandExecutor> logger)
        {
            _commandExecutor = commandExecutor;
            _logger = logger;
        }
        public void RunCommandsSequentially(List<string> commands)
        {
            foreach (var command in commands)
            {
                _logger.LogInformation($"Application: Comand: {command}");
                _commandExecutor.ExecuteCommand(command);
            }
        }
    }
}
