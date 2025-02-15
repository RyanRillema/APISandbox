using APISandbox.ViewModels.Orders;
using CommunityToolkit.Mvvm.ComponentModel;

namespace APISandbox.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private OrderGridViewModel _ordersView = new OrderGridViewModel();
}
