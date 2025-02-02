using APISandbox.Interfaces;
using APISandbox.Models;
using APISandbox.Services;
using APISandbox.ViewModels.Orders;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APISandbox.ViewModels;

public partial class MainViewModel : ViewModelBase
{    
    [ObservableProperty]
    private string _output;
    [ObservableProperty]
    private OrderGridViewModel _ordersView;
    [ObservableProperty]
    private Category _eCategory = Models.Category.spot;

    [RelayCommand]
    private async Task Go()
    {
        try
        {
            HistoricalOrderWebCallerParams thisOrderParams = new HistoricalOrderWebCallerParams(_eCategory);
            IHistoricalOrderWebCaller thisOrderWebCaller;
            IHistoricalOrder thisOrder;
            var Orders = new List<HistoricalOrder>();

            thisOrderWebCaller = new BybitHistoricalOrderWebCaller(thisOrderParams);
            thisOrder = new BybitHistoricalOrder();

            HttpClient client = thisOrderWebCaller.getClient();

            using (HttpRequestMessage request = new())
            {
                thisOrderWebCaller.SetupRequest(request);

                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        Output = await response.Content.ReadAsStringAsync();

                        thisOrder.PopulateOrderResult(Output);

                        Orders = thisOrder.PopulateHistoricalOrders();

                        OrdersView = new OrderGridViewModel(Orders);

                    } else
                    {
                        Output = response.StatusCode.ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Output = ex.Message;            
        }
    }

    [RelayCommand]
    private async Task SwitchCategory()
    {
       if (ECategory.Equals(Models.Category.spot))
        {
            ECategory = Models.Category.linear;
        } else
        {
            ECategory = Models.Category.spot;
        }
    }
}
