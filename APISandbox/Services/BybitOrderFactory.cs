using APISandbox.Interfaces;
using APISandbox.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace APISandbox.Services
{
    public class BybitOrderFactory : IOrderFactory
    {
        public List<HistoricalOrder> PopulateHistoricalOrders(string output)
        {
            var historicalOrderList = new List<HistoricalOrder>(); 
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
                _historicalOrder.Side = r.Side;
                historicalOrderList.Add(_historicalOrder);
            });

            return historicalOrderList;
        }
    }
}
