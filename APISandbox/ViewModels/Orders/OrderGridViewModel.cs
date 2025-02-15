using APISandbox.Interfaces;
using APISandbox.Models;
using APISandbox.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace APISandbox.ViewModels.Orders
{
    public partial class OrderGridViewModel : ViewModelBase
    {
        public ObservableCollection<Category> CategoryList { get; } = new();
        public ObservableCollection<Exchange> ExchangeList { get; } = new();
        public ObservableCollection<RJROrderViewModel> OrderList { get; } = new();

        [ObservableProperty]
        private Category _category = Models.Category.spot;
        [ObservableProperty]
        private Exchange _exchange = Models.Exchange.BitMex;

        HistoricalOrderWebCallerParams _orderParams = new HistoricalOrderWebCallerParams();
        IHistoricalOrderWebCaller _orderWebCaller; // = new BitMexHistoricalOrderWebCaller();

        public OrderGridViewModel()
        {
            CategoryList.Add(Models.Category.spot);
            CategoryList.Add(Models.Category.linear);
            ExchangeList.Add(Models.Exchange.Bybit);
            ExchangeList.Add(Models.Exchange.BitMex);
        }

        [RelayCommand]
        public async Task GetOrderHistory()
        {
            List<HistoricalOrder> orders;
            SetParamsForWebCall();
            
            if (Exchange==Exchange.Bybit)
            {
                _orderWebCaller = new BybitHistoricalOrderWebCaller(); ;
            }
            else if(Exchange == Exchange.BitMex)
            {
                _orderWebCaller = new BitMexHistoricalOrderWebCaller();
            }

            orders = await _orderWebCaller.GetOrderHistory(_orderParams);

            OrderList.Clear();

            RJROrderViewModel setOrder;
            foreach (var item in orders)
            {
                setOrder = new RJROrderViewModel(item);
                OrderList.Add(setOrder);
            }
        }

        private void SetParamsForWebCall()
        {
            _orderParams.Category = Category;
        }

    }
}
