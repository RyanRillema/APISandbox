using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static APISandbox.Models.OrderEnums;

namespace APISandbox.Models
{
    public class Account
    {
        public string Name;
        public Exchange Exchange;
        public string Key;
        public string Secret;

        public Account()
        {
            Name = "BitMex";
            Exchange = Exchange.BitMex;
            Key = "";
            Secret = "";
        }
    }
}
