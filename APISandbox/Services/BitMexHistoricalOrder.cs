using APISandbox.Interfaces;
using APISandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APISandbox.Services
{
    //RC: I would change this guys name. It works with BitMexHistoricalOrders but it itself is not a BitMexHistoricalOrder
    //There is a good change if you do other historical data you'll use this class to translate those pocos as well
    public class BitMexHistoricalOrder : IHistoricalOrder 
    {
        public List<HistoricalOrder> PopulateHistoricalOrders(string output)
        {
            //RC: variables in methods shouldn't have _ in their name
            var _historicalOrderList = new List<HistoricalOrder>(); 
            HistoricalOrder _historicalOrder = new HistoricalOrder(); 
            List<BitMexHistoricalOrderResultOrder> _orderResult = JsonSerializer.Deserialize<List<BitMexHistoricalOrderResultOrder>>(output);

            _orderResult.ForEach(r =>
            {
                _historicalOrder = new HistoricalOrder();
                _historicalOrder.Id = r.OrderID;
                _historicalOrder.Baseprice = r.Price;
                _historicalOrder.Cumexecqty = r.CumQty;
                _historicalOrder.Cumexecvalue = 0;
                _historicalOrder.Orderstatus = r.OrdStatus;
                _historicalOrder.Ordertype = r.OrdType;
                _historicalOrder.Price = r.Price;
                _historicalOrder.Qty = r.OrderQty;
                _historicalOrder.Avgprice = r.AvgPx;
                _historicalOrder.Symbol = r.Symbol;
                _historicalOrderList.Add(_historicalOrder);
            });

            return _historicalOrderList;
        }
    }
}
