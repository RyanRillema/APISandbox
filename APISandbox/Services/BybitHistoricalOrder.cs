using APISandbox.Interfaces;
using APISandbox.Models;
using APISandbox.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APISandbox.Services
{
    //RC: Same comment as the BitMexHistoricalOrder, not sure BybitHistoricalOrder is the right name
    public class BybitHistoricalOrder : IHistoricalOrder
    {
        public List<HistoricalOrder> PopulateHistoricalOrders(string output)
        {
            //RC: variables in methods shouldn't have _ in their name
            var _historicalOrderList = new List<HistoricalOrder>(); 
            HistoricalOrder _historicalOrder = new HistoricalOrder();
            BybitHistoricalOrderResult _orderResult = JsonSerializer.Deserialize<BybitHistoricalOrderResult>(output);

            _orderResult.Result.List.ForEach(r =>
            {
                _historicalOrder = new HistoricalOrder();
                _historicalOrder.Id = r.OrderId;
                _historicalOrder.Baseprice = double.Parse(r.BasePrice, System.Globalization.CultureInfo.InvariantCulture);
                _historicalOrder.Cumexecqty = double.Parse(r.CumExecQty, System.Globalization.CultureInfo.InvariantCulture);
                _historicalOrder.Cumexecvalue = double.Parse(r.CumExecValue, System.Globalization.CultureInfo.InvariantCulture);
                _historicalOrder.Orderstatus = r.OrderStatus;
                _historicalOrder.Ordertype = r.OrderType;
                _historicalOrder.Price = double.Parse(r.Price, System.Globalization.CultureInfo.InvariantCulture);
                _historicalOrder.Qty = double.Parse(r.Qty, System.Globalization.CultureInfo.InvariantCulture);
                _historicalOrder.Avgprice = double.Parse(r.AvgPrice, System.Globalization.CultureInfo.InvariantCulture);
                _historicalOrder.Symbol = r.Symbol;
                _historicalOrderList.Add(_historicalOrder);
            });

            return _historicalOrderList;
        }
    }
}
