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
    private OrderGridViewModel _ordersView = new OrderGridViewModel();
}
