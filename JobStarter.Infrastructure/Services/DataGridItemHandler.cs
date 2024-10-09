using JobStarter.Application.Interfaces;
using JobStarter.Domain.Models.DataGrid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobStarter.Infrastructure.Services
{
    internal class DataGridItemHandler : IDataGridItem
    {

        public ObservableCollection<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(Item item)
        {
            throw new NotImplementedException();
        }

        void IDataGridItem.AddItem(string text)
        {
            throw new NotImplementedException();
        }
    }
}
