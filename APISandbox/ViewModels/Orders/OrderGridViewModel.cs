using APISandbox.Interfaces;
using APISandbox.Models;
using APISandbox.Services;
using BitMEX;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using static APISandbox.Models.OrderEnums;

namespace APISandbox.ViewModels.Orders
{
    public partial class OrderGridViewModel : ViewModelBase
    {
        public ObservableCollection<Category> CategoryList { get; } = new();
        public ObservableCollection<Exchange> ExchangeList { get; } = new();
        public ObservableCollection<RJROrderViewModel> OrderList { get; } = new();

        [ObservableProperty]
        private Category _category = Category.spot;
        [ObservableProperty]
        private Exchange _exchange = Exchange.BitMex;
        [ObservableProperty]
        private string _startDate = DateTime.Now.ToString();
        [ObservableProperty]
        private string _endDate = DateTime.Now.ToString();

        HistoricalOrderWebCallerParams _orderParams = new HistoricalOrderWebCallerParams();
        IHistoricalOrderWebCaller _orderWebCaller;

        public OrderGridViewModel()
        {
            // RJR Look for a way to populate all enums
            CategoryList.Add(Category.spot);
            CategoryList.Add(Category.linear);
            ExchangeList.Add(Exchange.Bybit);
            ExchangeList.Add(Exchange.BitMex);

            GetInstruments();
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
                //BitMEXApi bitmex = new BitMEXApi("ZSbLa4SnZk5zh4r08wnPw7RM", "rMeqAzEGaGSLJGphWsUjou-_49-uyzK5wmxnoqnzoAAczeCD");
                // var orderBook = bitmex.GetOrderBook("XBTUSD", 3);
                //var test = bitmex.GetOrders();
                //var test = bitmex.PostOrders();

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
        public async Task GetInstruments()
        {
            List<Instrument> instruments;
            SetParamsForWebCall();

            if (Exchange == Exchange.Bybit)
            {
                _orderWebCaller = new BybitHistoricalOrderWebCaller(); ;
            }
            else if (Exchange == Exchange.BitMex)
            {
                _orderWebCaller = new BitMexHistoricalOrderWebCaller();
                //BitMEXApi bitmex = new BitMEXApi("ZSbLa4SnZk5zh4r08wnPw7RM", "rMeqAzEGaGSLJGphWsUjou-_49-uyzK5wmxnoqnzoAAczeCD");
                // var orderBook = bitmex.GetOrderBook("XBTUSD", 3);
                //var test = bitmex.GetOrders();
                //var test = bitmex.PostOrders();

            }

            var tem = await _orderWebCaller.GetSymbols();
        }
        private void SetParamsForWebCall()
        {
            _orderParams.Category = Category;
            _orderParams.Exchange = Exchange;

            StartDate = StartDate.Substring(0, 19);
            EndDate = EndDate.Substring(0, 19);

            _orderParams.StartTime = DateTime.Parse(StartDate);
            _orderParams.EndTime = DateTime.Parse(EndDate);
        }

    }
}
