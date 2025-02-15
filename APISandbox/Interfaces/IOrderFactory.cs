using APISandbox.Models;
using System.Collections.Generic;

namespace APISandbox.Interfaces
{
    public interface IOrderFactory
    {        
        List<HistoricalOrder> PopulateHistoricalOrders(string output);
    }
}
