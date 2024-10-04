using JobStarter.Application.Services;
using JobStarter.Domain.Models.DataGrid;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Item> Items { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(ILogger<MainWindow> logger, CommandRunnerService commandRunnerService)
        {
            InitializeComponent();
            _logger = logger;
            _commandRunnerService = commandRunnerService;

            Items = new ObservableCollection<Item>()
                {
                new Item { Id = 1, Text = "Przykład 1" },
                new Item { Id = 2, Text = "Przykład 2" }
            };

            DataContext = this;
            
            // tmp dodaj wiersze
            int newId = Items.Count + 1;
            Items.Add(new Item { Id = newId, Text = "Ser" });


            //  TMP DEBUG command
            var tmpList = new List<string>();
            tmpList.Add("Test");
            _commandRunnerService.RunCommandsSequentially(tmpList);


        }
    }
}
