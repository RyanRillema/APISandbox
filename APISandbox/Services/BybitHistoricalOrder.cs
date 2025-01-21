using APISandbox.Interfaces;
using APISandbox.Models;
using APISandbox.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISandbox.Services
{
    public class BybitHistoricalOrder : IHistoricalOrder
    {
        public BybitHistoricalOrderResult OrderResult;
        public ObservableCollection<RJROrderViewModel> PopulateRJROrders()
        {
            var RJROverList = new ObservableCollection<RJROrderViewModel>();

            BybitHistoricalOrder Item;
            RJROrderViewModel RJROrder;
            OrderResult.result.list.ForEach(r => {
                RJROrder = new RJROrderViewModel();
                RJROrder.setID(r.orderId);
                RJROrder.setBasePrice(r.basePrice);
                RJROrder.setCumExecQty(r.cumExecQty);
                RJROrder.setCumExecValue(r.cumExecValue);
                RJROrder.setOrderStatus(r.orderStatus);
                RJROrder.setOrderType(r.orderType);
                RJROrder.setPrice(r.price);
                RJROrder.setQty(r.qty);
                RJROrder.setAvgPrice(r.avgPrice);
                RJROrder.setSymbol(r.symbol);

                RJROverList.Add(RJROrder);
            });

            return RJROverList;
        }
    }
}
