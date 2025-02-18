using Microsoft.VisualBasic;
using System;
using static APISandbox.Models.OrderEnums;

namespace APISandbox.Models
{
    public class HistoricalOrderWebCallerParams
    {

        public Category Category;
        public Exchange Exchange;
        public DateTime StartTime;
        public DateTime EndTime;

        public HistoricalOrderWebCallerParams(Category setCategory = Category.spot, Exchange setExchange = Exchange.BitMex)
        {
            Category = setCategory;
            Exchange = setExchange;
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
        }

    }
}
