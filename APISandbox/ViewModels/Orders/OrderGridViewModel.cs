using APISandbox.Interfaces;
using APISandbox.Models;
using APISandbox.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using static APISandbox.Models.OrderEnums;

namespace APISandbox.ViewModels.Orders
{
    public partial class OrderGridViewModel : ViewModelBase
    {
        public ObservableCollection<String> AccountNameList { get; } = new();
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
        [ObservableProperty]
        private string _accountName;
        private List<Account> AccountList { get; } = new();

        AccountFactory _accountFactory = new AccountFactory();

        HistoricalOrderWebCallerParams _orderParams = new HistoricalOrderWebCallerParams();
        IHistoricalOrderWebCaller _orderWebCaller;

        public OrderGridViewModel()
        {
            // RJR Look for a way to populate all enums
            CategoryList.Add(Category.spot);
            CategoryList.Add(Category.linear);
            ExchangeList.Add(Exchange.Bybit);
            ExchangeList.Add(Exchange.BitMex);

            //GetInstruments();

            AccountList = _accountFactory.ReadAccountList();
            LoadAccountNames();
        }

        [RelayCommand]
        public async Task GetOrderHistory()
        {
            List<HistoricalOrder> orders;
            SetParamsForWebCall();

            if (Exchange == Exchange.Bybit)
            {
                _orderWebCaller = new BybitHistoricalOrderWebCaller(); ;
            }
            else if (Exchange == Exchange.BitMex)
            {
                _orderWebCaller = new BitMexHistoricalOrderWebCaller();
                //BitMEXApi bitmex = new BitMEXApi("ZSbLa4SnZk5zh4r08wnPw7RM", "rMeqAzEGaGSLJGphWsUjou-_49-uyzK5wmxnoqnzoAAczeCD");

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
            }

            var tem = await _orderWebCaller.GetSymbols();
        }
        private void SelectAccount()
        {
            _orderParams.Account = AccountList.Find(x => x.Name == AccountName);

            //_exchange = _orderParams.Account.Exchange;
            //_category = Category.linear;
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
        private void LoadAccountNames()
        {
            AccountNameList.Clear();
            foreach (var item in AccountList)
            {
                AccountNameList.Add(item.Name);
            }
        }
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "AccountName")
            {
                SelectAccount();
            }
        }
        
    }
}
