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

        public RJROrderViewModel() { }
        
        public void setID(string id)
        {
            Id = id;
        }

        public void setTimeStamp(string timestamp)
        {
            Timestamp = timestamp;
        }
        
        public void setSymbol(string symbol)
        {
            Symbol = symbol;
        }

        public void setOrderType(string OrderType)
        {
            Ordertype = OrderType;
        }

        public void setAvgPrice(string AvgPrice)
        {
            Avgprice = AvgPrice;
        }

        public void setPrice(string setPrice)
        {
            Price = setPrice;
        }

        public void setOrderStatus(string OrderStatus)
        {
            Orderstatus = OrderStatus;
        }

        public void setCumExecValue(string CumExecValue)
        {
            Cumexecvalue = CumExecValue;
        }

        public void setBasePrice(string BasePrice)
        {
            Baseprice = BasePrice;
        }

        public void setCumExecQty(string CumExecQty)
        {
            Cumexecqty = CumExecQty;
        }

        public void setQty(string setQty)
        {
            Qty = setQty;
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
