using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APISandbox.Models
{
    public class BitMexHistoricalOrderResult
    {
        [JsonPropertyName("list")] public List<BitMexHistoricalOrderResultOrder> List { get; set; }
    }
        public class BitMexHistoricalOrderResultOrder
    {
        [JsonPropertyName("account")] public double Account { get; set; }
        [JsonPropertyName("avgPx")] public double AvgPx { get; set; }
        [JsonPropertyName("cumQty")] public double CumQty { get; set; }
        [JsonPropertyName("currency")] public string Currency { get; set; }
        [JsonPropertyName("leavesQty")] public double LeavesQty { get; set; }
        [JsonPropertyName("ordStatus")] public string OrdStatus { get; set; }
        [JsonPropertyName("ordType")] public string OrdType { get; set; }
        [JsonPropertyName("orderID")] public string OrderID { get; set; }
        [JsonPropertyName("orderQty")] public double OrderQty { get; set; }
        [JsonPropertyName("price")] public double Price { get; set; }
        [JsonPropertyName("side")] public string Side { get; set; }
        [JsonPropertyName("symbol")] public string Symbol { get; set; }
        [JsonPropertyName("text")] public string Text { get; set; }
        [JsonPropertyName("timeInForce")] public string TimeInForce { get; set; }
        [JsonPropertyName("timestamp")] public string Timestamp { get; set; }
        [JsonPropertyName("transactTime")] public string TransactTime { get; set; }
        [JsonPropertyName("workingIndicator")] public bool WorkingIndicator { get; set; }
    }
    

}
