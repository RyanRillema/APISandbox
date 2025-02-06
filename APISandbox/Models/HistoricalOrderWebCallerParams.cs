using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISandbox.Models
{
    public enum Category
    {
        spot,linear
    }
    public enum Exchange
    {
        Bybit, BitMex
    }
    public class HistoricalOrderWebCallerParams
    {

        public Category Category;
        public Exchange Exchange;

        public HistoricalOrderWebCallerParams(Category setCategory = Category.spot, Exchange setExchange = Exchange.BitMex)
        {
            Category = setCategory;
            Exchange = setExchange;
        }

    }
}
