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
        public string id;
        public string timestamp;
        public string symbol;
        public string ordertype;
        public string avgprice;
        public string price;
        public string orderstatus;
        public string cumexecvalue;
        public string baseprice;
        public string cumexecfee;
        public string cumexecqty;
        public string qty;
    }
}
