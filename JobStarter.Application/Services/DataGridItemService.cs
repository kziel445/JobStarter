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
        public readonly IDataGridItem _dataGridItem;
        public readonly ObservableCollection<Item> _items;
        public DataGridItemService(ILogger<IDataGridItem> logger, IDataGridItem dataGridItem)
        {
            _logger = logger;
            _items = new ObservableCollection<Item>();
            _dataGridItem = dataGridItem;
        }
        public ObservableCollection<Item> GetItems()
        {
            return _dataGridItem.GetItems();
        }
        public void AddItem(string text)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
