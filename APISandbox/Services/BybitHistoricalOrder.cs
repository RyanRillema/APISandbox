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
        public List<HistoricalOrder> PopulateHistoricalOrders()
        {
            var historicalOrderList = new List<HistoricalOrder>();
            HistoricalOrder historicalOrder = new HistoricalOrder();
            
            OrderResult.result.list.ForEach(r => {
                historicalOrder.id = r.orderId;
                historicalOrder.baseprice = r.basePrice;
                historicalOrder.cumexecqty = r.cumExecQty;
                historicalOrder.cumexecvalue = r.cumExecValue;
                historicalOrder.orderstatus = r.orderStatus;
                historicalOrder.ordertype = r.orderType;
                historicalOrder.price = r.price;
                historicalOrder.qty = r.qty;
                historicalOrder.avgprice = r.avgPrice;
                historicalOrder.symbol = r.symbol;
                historicalOrderList.Add(historicalOrder);
            });

            return historicalOrderList;
        }
    }
}
