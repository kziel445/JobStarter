using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobStarter.Domain.Models.DataGrid;

namespace JobStarter.Application.Interfaces
{
    public interface IDataGridItem
    {
        public ObservableCollection<Item> GetItems();
        public void AddItem(string text);
        public void RemoveItem(Item item);
    }
}
