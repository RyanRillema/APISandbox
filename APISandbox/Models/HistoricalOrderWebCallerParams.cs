using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISandbox.Models
{
    //RC: If an enum is used outside of the HistoricalOrderWebCallerParams class, it shouldn't be in the HistoricalOrderWebCallerParams file.
    //Enums are usually stored in their own file (so you'd have Category.cs and Exchange.cs) but also often people will have an enums.cs file because they're usually quite short.
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
