﻿using JobStarter.Application.Interfaces;
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
using System.Windows.Threading;

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
        private DispatcherTimer _timer;
        private TimeSpan elapsedTime;

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

            // timer
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();

            elapsedTime = TimeSpan.Zero;


            // tmp dodaj wiersze
            //int newId = Items.Count + 1;
            //Items.Add(new Item { Id = newId, Text = "Ser" });


            //  TMP DEBUG command
            //var tmpList = new List<string>();
            //tmpList.Add("Test");
            //_commandRunnerService.RunCommandsSequentially(tmpList);


        }
        // timer_tick
        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime = elapsedTime.Add(_timer.Interval);
            TimeLabel.Content = "Timer: " + elapsedTime.ToString(@"hh\:mm\:ss");
        }

        // data grid buttons
        private void AddRowButton_Click(object sender, RoutedEventArgs e)
        {
            _dataGridItemService.AddItem("{Wpisz komende}");
        }

        private void RemoveRowButton_Click(object sender, RoutedEventArgs e)
        {
            if (CommandGrid.SelectedItem is Item selectedItem)
            {
                _dataGridItemService.RemoveItem(selectedItem);
            }
            else
            {
                _dataGridItemService.RemoveItem(_dataGridItemService.GetItems().Last());
            }
        }

        private void RunCommandsButton_Click(object sender, RoutedEventArgs e)
        {
            _commandRunnerService.RunCommandsSequentially(
                _dataGridItemService.GetItems().Select(item => item.Text).ToList()
                );
        }
        // timer buttons
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Start();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            elapsedTime = TimeSpan.Zero;
            TimeLabel.Content = "Timer: " + elapsedTime.ToString(@"hh\:mm\:ss");
        }
    }
}
