using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISandbox.Models
{
    public class HistoricalOrder
    {
        public string Id;
        public string Timestamp;
        public string Symbol;
        public string Ordertype;
        public string Avgprice;
        public string Price;
        public string Orderstatus;
        public string Cumexecvalue;
        public string Baseprice;
        public string Cumexecfee;
        public string Cumexecqty;
        public string Qty;
    }
}
