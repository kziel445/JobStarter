using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace JobStarter
{
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider= serviceCollection.BuildServiceProvider();


            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();

            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // logger
            services.AddLogging(config =>
            {
                config.AddConsole();
                config.AddFile("Logs/app.log");
                config.SetMinimumLevel(LogLevel.Information);
            });

            // services.AddSingleton<ICommandExecutor, CommandExecutor>();
            // services.AddSingleton<CommandRunnerService>();

            services.AddSingleton<MainWindow>();
        }
    }
}
