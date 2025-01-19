using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISandbox.ViewModels.Orders
{
    public abstract partial class OrderViewModel : ViewModelBase
    {
        public OrderViewModel()
        {
            
        }

        public abstract void PopulateResponse(string Response);
                
        public abstract void PopulateRJROrders(ObservableCollection<RJROrderViewModel> Orders);
        
    }
}
