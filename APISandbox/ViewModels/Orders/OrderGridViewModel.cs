using APISandbox.Interfaces;
using APISandbox.Models;
using APISandbox.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        public ObservableCollection<Category> CategoryList { get; } = new();
        [ObservableProperty]
        private Category _category = Models.Category.spot;

        HistoricalOrderWebCallerParams _orderParams = new HistoricalOrderWebCallerParams();
        IHistoricalOrderWebCaller _orderWebCaller = new BybitHistoricalOrderWebCaller();

        public OrderGridViewModel()
        {
            CategoryList.Add(Models.Category.spot);
            CategoryList.Add(Models.Category.linear);
        }

        [RelayCommand]
        public async Task GetOrderHistory()
        {
            List<HistoricalOrder> orders;
            SetParamsForWebCall();
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
