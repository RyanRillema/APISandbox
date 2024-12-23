using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
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

        [ObservableProperty]
        private string _ID;
        private string _Timestamp;
        private string _Symbol;
        private string _OrderType;
        private string _AvgPrice;
        private double _Price;
        private string _OrderStatus;
        private string _CumExecValue;
        private double _BasePrice;
        private double _CumExecFee;
        private double _CumExecQty;
        private double _Qty;    

    }
}
