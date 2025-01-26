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
    public partial class RJROrderViewModel : ViewModelBase
    {

        public RJROrderViewModel(HistoricalOrder setOrder)
        {
            Id = setOrder.id;
            Timestamp = setOrder.timestamp;
            Symbol = setOrder.symbol;
            Ordertype = setOrder.ordertype;
            Avgprice = setOrder.avgprice;
            Price = setOrder.price;
            Orderstatus = setOrder.orderstatus;
            Cumexecvalue = setOrder.cumexecvalue;
            Baseprice = setOrder.baseprice;
            Cumexecqty  = setOrder.cumexecqty;
            Qty = setOrder.qty;
        }
        
        [ObservableProperty]
        private string _id;
        [ObservableProperty]
        private string _timestamp;
        [ObservableProperty]
        private string _symbol;
        [ObservableProperty]
        private string _ordertype;
        [ObservableProperty]
        private string _avgprice;
        [ObservableProperty]
        private string _price;
        [ObservableProperty]
        private string _orderstatus;
        [ObservableProperty]
        private string _cumexecvalue;
        [ObservableProperty]
        private string _baseprice;
        [ObservableProperty]
        private string _cumexecfee;
        [ObservableProperty]
        private string _cumexecqty;
        [ObservableProperty]
        private string _qty;

    }
}
