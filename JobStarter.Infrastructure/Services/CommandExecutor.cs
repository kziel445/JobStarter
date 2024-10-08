using JobStarter.Application.Interfaces;
using JobStarter.Domain.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace JobStarter.Infrastructure.Services
{
    public class CommandExecutor : ICommandExecutor
    {
        public readonly ILogger<ICommandExecutor> _logger;
        private ProcessStartInfo processStartInfo;

        public CommandExecutor(ILogger<ICommandExecutor> logger)
        {
            _logger = logger;
        }

        public void ExecuteCommand(string commandText)
        {
            processStartInfo = new ProcessStartInfo("cmd", $"/c {commandText}")
            {
                RedirectStandardOutput = true,  // Przekierowanie wyjścia
                UseShellExecute = false,        // Użycie powłoki systemowej
                CreateNoWindow = true           // Ukrycie okna cmd
            };

            Process process = new Process
            {
                StartInfo = processStartInfo
            };

            process.Start();

            // Odczytanie wyniku
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            _logger.LogInformation($"Infrastructure: {commandText} executed, result: {result}");
        }
    }
}
