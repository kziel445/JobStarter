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
    public class DataGridItemService : IDataGridItem
    {
        public readonly ILogger<IDataGridItem> _logger;
        public readonly ObservableCollection<Item> _items;
        public DataGridItemService(
            ILogger<IDataGridItem> logger,
            ObservableCollection<Item> items)
        {
            _logger = logger;
            _items = items;
        }
        public ObservableCollection<Item> GetItems()
        {
            return _items;
        }
        public void AddItem(string text = "{default}")
        {
            _items.Add(new Item() { Id = _items.Count + 1, Text = text });
        }

        public void RemoveItem(Item item)
        {
            _items.Remove(item);
        }
    }
}
