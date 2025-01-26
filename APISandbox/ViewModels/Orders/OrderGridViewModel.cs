using APISandbox.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISandbox.ViewModels.Orders
{
    public partial class OrderGridViewModel : ViewModelBase
    {
        public ObservableCollection<RJROrderViewModel> OrderList { get; } = new();
        
        public OrderGridViewModel(List<HistoricalOrder> setOrderList)
        {
            RJROrderViewModel setOrder;
            foreach (var item in setOrderList)
            {
                setOrder = new RJROrderViewModel(item);
                OrderList.Add(setOrder);
            }

        }

    }
}
