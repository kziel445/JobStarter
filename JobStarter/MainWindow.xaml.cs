using JobStarter.Application.Interfaces;
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
        private readonly IDataGridItem _dataGridItemService;
        public ObservableCollection<Item> Items => _dataGridItemService.GetItems();

        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(
            ILogger<MainWindow> logger,
            CommandRunnerService commandRunnerService,
            IDataGridItem dataGridItemService
            )
        {
            InitializeComponent();
            _logger = logger;
            _commandRunnerService = commandRunnerService;
            _dataGridItemService = dataGridItemService;

            DataContext = this;
            
            // tmp dodaj wiersze
            //int newId = Items.Count + 1;
            //Items.Add(new Item { Id = newId, Text = "Ser" });


            //  TMP DEBUG command
            //var tmpList = new List<string>();
            //tmpList.Add("Test");
            //_commandRunnerService.RunCommandsSequentially(tmpList);


        }
        // buttons
        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            // _dataGridItemService.AddItem("{Wpisz komende}");
            // var item = new Item { Id = Items.Count + 1, Text = "{Wpisz komende}"};
            // Items.Add(item);
        }
    }
}
