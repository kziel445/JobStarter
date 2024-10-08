﻿using JobStarter.Application.Interfaces;
using JobStarter.Application.Services;
using JobStarter.Domain.Models.DataGrid;
using JobStarter.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Windows;

namespace JobStarter
{
    public partial class App : System.Windows.Application
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

            services.AddSingleton<ICommandExecutor, CommandExecutor>();
            services.AddSingleton<CommandRunnerService>();
            services.AddTransient<IDataGridItem>(provider =>
            {
                // TODO: tymczasowa inicjalizacja
                var logger = provider.GetRequiredService<ILogger<IDataGridItem>>();
                
                var Items = new ObservableCollection<Item>()
                {
                new Item { Id = 1, Text = "Przykład 1" },
                new Item { Id = 2, Text = "Przykład 2" }
                };
                //// 
                return new DataGridItemService(logger, Items);
            });

            

            services.AddSingleton<MainWindow>();
        }
    }
}
