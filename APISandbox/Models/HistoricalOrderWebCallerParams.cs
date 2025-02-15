using static APISandbox.Models.OrderEnums;

namespace APISandbox.Models
{
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
