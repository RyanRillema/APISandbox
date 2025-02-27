using Microsoft.VisualBasic;
using System;
using static APISandbox.Models.OrderEnums;

namespace APISandbox.Models
{
    public class HistoricalOrderWebCallerParams
    {
        public Account Account;
        public Category Category;
        public Exchange Exchange;
        public DateTime StartTime;
        public DateTime EndTime;

        public HistoricalOrderWebCallerParams()
        {
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
        }

    }
}
