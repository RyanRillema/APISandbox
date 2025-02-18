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
    public class BitMexOrderFactory : IOrderFactory
    {
        public List<HistoricalOrder> PopulateHistoricalOrders(string output)
        {
            var historicalOrderList = new List<HistoricalOrder>(); 
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
                _historicalOrder.Side = r.Side;
                historicalOrderList.Add(_historicalOrder);
            });

            return historicalOrderList;
        }

        public List<Instrument> PopulateInstrumentList(string output)
        {
            var instrumentList = new List<Instrument>();
            Instrument _instrument = new Instrument();
            List<BitMexInstrumentList> _orderResult = JsonSerializer.Deserialize<List<BitMexInstrumentList>>(output);

            _orderResult.ForEach(r =>
            {
                _instrument = new Instrument();
                _instrument.Symbol = r.symbol;
                instrumentList.Add(_instrument);
            });

            return instrumentList;
        }
    }
}
