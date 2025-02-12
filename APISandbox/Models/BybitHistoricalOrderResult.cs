using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APISandbox.Models
{

    public class BybitHistoricalOrderResult
    {
        //RC: This is a region and can be collapsed for easier reading
        #region Sub classes

        

        #endregion
        
        [JsonPropertyName("retCode")] public double RetCode { get; set; }
        [JsonPropertyName("retMsg")] public string RetMsg { get; set; }
        [JsonPropertyName("result")] public BybitResult Result { get; set; }
        [JsonPropertyName("retExtInfo")] public object RetExtInfo { get; set; }
        [JsonPropertyName("time")] public double Time { get; set; }

        //RC: I seldom use classes inside of classes but I think I actually kind of like this.
        //I would rather define them in a region at the top of the class though
        public class BybitResult //RC: Maybe rename this class to something more descriptive
        {
            [JsonPropertyName("nextPageCursor")] public string NextPageCursor { get; set; }
            [JsonPropertyName("category")] public string Category { get; set; }
            [JsonPropertyName("list")] public List<BybitHistoricalOrder> List { get; set; }

        }

        public class BybitHistoricalOrder //RC: I like this class being named BybitHistoricalOrder. That is what it defines. I think the other BybitHistoricalOrder class should be renamed
        {
            [JsonPropertyName("symbol")] public string Symbol { get; set; }
            [JsonPropertyName("orderType")] public string OrderType { get; set; }
            [JsonPropertyName("orderLinkId")] public string OrderLinkId { get; set; }
            [JsonPropertyName("slLimitPrice")] public string SlLimitPrice { get; set; }
            [JsonPropertyName("orderId")] public string OrderId { get; set; }
            [JsonPropertyName("cancelType")] public string CancelType { get; set; }
            [JsonPropertyName("avgPrice")] public string AvgPrice { get; set; }
            [JsonPropertyName("stopOrderType")] public string StopOrderType { get; set; }
            [JsonPropertyName("lastPriceOnCreated")] public string LastPriceOnCreated { get; set; }
            [JsonPropertyName("orderStatus")] public string OrderStatus { get; set; }
            [JsonPropertyName("takeProfit")] public string TakeProfit { get; set; }
            [JsonPropertyName("cumExecValue")] public string CumExecValue { get; set; }
            [JsonPropertyName("smpType")] public string SmpType { get; set; }
            [JsonPropertyName("triggerDirection")] public int TriggerDirection { get; set; }
            [JsonPropertyName("blockTradeId")] public string BlockTradeId { get; set; }
            [JsonPropertyName("rejectReason")] public string RejectReason { get; set; }
            [JsonPropertyName("isLeverage")] public string IsLeverage { get; set; }
            [JsonPropertyName("price")] public string Price { get; set; }
            [JsonPropertyName("orderIv")] public string OrderIv { get; set; }
            [JsonPropertyName("createdTime")] public string CreatedTime { get; set; }
            [JsonPropertyName("tpTriggerBy")] public string TpTriggerBy { get; set; }
            [JsonPropertyName("positionIdx")] public int PositionIdx { get; set; }
            [JsonPropertyName("trailingPercentage")] public string TrailingPercentage { get; set; }
            [JsonPropertyName("timeInForce")] public string TimeInForce { get; set; }
            [JsonPropertyName("leavesValue")] public string LeavesValue { get; set; }
            [JsonPropertyName("basePrice")] public string BasePrice { get; set; }
            [JsonPropertyName("updatedTime")] public string UpdatedTime { get; set; }
            [JsonPropertyName("side")] public string Side { get; set; }
            [JsonPropertyName("smpGroup")] public int SmpGroup { get; set; }
            [JsonPropertyName("triggerPrice")] public string TriggerPrice { get; set; }
            [JsonPropertyName("tpLimitPrice")] public string TpLimitPrice { get; set; }
            [JsonPropertyName("trailingValue")] public string TrailingValue { get; set; }
            [JsonPropertyName("cumExecFee")] public string CumExecFee { get; set; }
            [JsonPropertyName("slTriggerBy")] public string SlTriggerBy { get; set; }
            [JsonPropertyName("leavesQty")] public string LeavesQty { get; set; }
            [JsonPropertyName("closeOnTrigger")] public bool CloseOnTrigger { get; set; }
            [JsonPropertyName("placeType")] public string PlaceType { get; set; }
            [JsonPropertyName("cumExecQty")] public string CumExecQty { get; set; }
            [JsonPropertyName("reduceOnly")] public bool ReduceOnly { get; set; }
            [JsonPropertyName("activationPrice")] public string ActivationPrice { get; set; }
            [JsonPropertyName("qty")] public string Qty { get; set; }
            [JsonPropertyName("stopLoss")] public string StopLoss { get; set; }
            [JsonPropertyName("marketUnit")] public string MarketUnit { get; set; }
            [JsonPropertyName("smpOrderId")] public string SmpOrderId { get; set; }
            [JsonPropertyName("triggerBy")] public string TriggerBy { get; set; }
        }
    }
}
