﻿using APISandbox.Interfaces;
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
    public class BybitHistoricalOrder : IHistoricalOrder
    {
        public List<HistoricalOrder> PopulateHistoricalOrders(string output)
        {
            var _historicalOrderList = new List<HistoricalOrder>();
            HistoricalOrder _historicalOrder = new HistoricalOrder();
            BybitHistoricalOrderResult _orderResult = JsonSerializer.Deserialize<BybitHistoricalOrderResult>(output);

            _orderResult.Result.List.ForEach(r =>
            {
                _historicalOrder = new HistoricalOrder();
                _historicalOrder.Id = r.OrderId;
                _historicalOrder.Baseprice = Double.Parse(r.BasePrice);
                _historicalOrder.Cumexecqty = Double.Parse(r.CumExecQty);
                _historicalOrder.Cumexecvalue = Double.Parse(r.CumExecValue);
                _historicalOrder.Orderstatus = r.OrderStatus;
                _historicalOrder.Ordertype = r.OrderType;
                _historicalOrder.Price = Double.Parse(r.Price);
                _historicalOrder.Qty = Double.Parse(r.Qty);
                _historicalOrder.Avgprice = Double.Parse(r.AvgPrice);
                _historicalOrder.Symbol = r.Symbol;
                _historicalOrderList.Add(_historicalOrder);
            });

            return _historicalOrderList;
        }
    }
}
