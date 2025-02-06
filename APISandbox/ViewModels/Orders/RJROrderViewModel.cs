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
            Id = setOrder.Id;
            Timestamp = setOrder.Timestamp;
            Symbol = setOrder.Symbol;
            Ordertype = setOrder.Ordertype;
            Avgprice = setOrder.Avgprice;
            Price = setOrder.Price;
            Orderstatus = setOrder.Orderstatus;
            Cumexecvalue = setOrder.Cumexecvalue;
            Baseprice = setOrder.Baseprice;
            Cumexecqty  = setOrder.Cumexecqty;
            Qty = setOrder.Qty;
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
        private double _avgprice;
        [ObservableProperty]
        private double _price;
        [ObservableProperty]
        private string _orderstatus;
        [ObservableProperty]
        private double _cumexecvalue;
        [ObservableProperty]
        private double _baseprice;
        [ObservableProperty]
        private double _cumexecfee;
        [ObservableProperty]
        private double _cumexecqty;
        [ObservableProperty]
        private double _qty;

    }
}
