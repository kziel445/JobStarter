using JobStarter.Application.Interfaces;
using JobStarter.Domain.Models.DataGrid;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStarter.Application.Services
{
    internal class DataGridItemService : IDataGridItem
    {
        public readonly ILogger<IDataGridItem> _logger;
        public readonly ObservableCollection<Item> _items;
        public DataGridItemService(ILogger<IDataGridItem> logger)
        {
            _logger = logger;
            _items= new ObservableCollection<Item>();
        }

        public void AddItem(string text)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
