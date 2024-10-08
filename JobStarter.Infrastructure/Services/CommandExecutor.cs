using JobStarter.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace JobStarter.Infrastructure.Services
{
    public class CommandExecutor : ICommandExecutor
    {
        public readonly ILogger<ICommandExecutor> _logger;

        public CommandExecutor(ILogger<ICommandExecutor> logger)
        {
            _logger = logger;
        }

        public void ExecuteCommand(string commandText)
        {
            System.Diagnostics.Process.Start("CMD.exe",$"/c {commandText}");
            _logger.LogError("Infrastructure: Not Impemented");
            // throw new NotImplementedException();
        }


    }
}
