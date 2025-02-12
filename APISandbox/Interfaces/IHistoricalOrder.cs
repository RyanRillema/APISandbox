﻿//RC: Unnecessary using statements (I see this in other classes as well but won't highlight it in each one)
using APISandbox.Models;
using APISandbox.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISandbox.Interfaces
{
    public interface IHistoricalOrder
    {        
        List<HistoricalOrder> PopulateHistoricalOrders(string output);
    }
}
