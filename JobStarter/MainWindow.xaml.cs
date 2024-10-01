using JobStarter.Application.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JobStarter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILogger<MainWindow> _logger;  // Logger
        private readonly CommandRunnerService _commandRunnerService;

        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(ILogger<MainWindow> logger, CommandRunnerService commandRunnerService)
        {
            InitializeComponent();
            _logger = logger;
            _commandRunnerService = commandRunnerService;

            // DEBUG command
            var tmpList = new List<string>();
            tmpList.Add("Test");
            _commandRunnerService.RunCommandsSequentially(tmpList);
        }
    }
}
