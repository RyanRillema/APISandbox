using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace APISandbox.ViewModels.Orders
{
    public class BybitViewModel : OrderViewModel
    {
        public double retCode { get; set; }
        public string retMsg { get; set; }
        public BybitResult result { get; set; }
        public object retExtInfo { get; set; }
        public double time { get; set; }

        public override void PopulateResponse(string Response)
        {
            throw new NotImplementedException();
        }

        public override void PopulateRJROrders(ObservableCollection<RJROrderViewModel> Orders)
        {
            BybitList Item;
            RJROrderViewModel RJROrder;
            result.list.ForEach(r => {
                Item = r;
                RJROrder = new RJROrderViewModel();
                RJROrder.setID(Item.orderId);
                RJROrder.setBasePrice(Item.basePrice);
                RJROrder.setCumExecQty(Item.cumExecQty);
                RJROrder.setCumExecValue(Item.cumExecValue);
                RJROrder.setOrderStatus(Item.orderStatus);
                RJROrder.setOrderType(Item.orderType);
                RJROrder.setPrice(Item.price);
                RJROrder.setQty(Item.qty);
                RJROrder.setAvgPrice(Item.avgPrice);
                RJROrder.setSymbol(Item.symbol);

                Orders.Add(RJROrder);
            }); 
        }
    }

    public class BybitResult
    {
        public string nextPageCursor { get; set; }
        public string category {  get; set; }
        public List<BybitList> list { get; set; }

    }

    public class BybitList
    {
        public string symbol { get; set; }
        public string orderType { get; set; }
        public string orderLinkId { get; set; }
        public string slLimitPrice { get; set; }
        public string orderId { get; set; }
        public string cancelType { get; set; }
        public string avgPrice { get; set; }
        public string stopOrderType { get; set; }
        public string lastPriceOnCreated { get; set; }
        public string orderStatus { get; set; }
        public string takeProfit { get; set; }
        public string cumExecValue { get; set; }
        public string smpType { get; set; }
        public int triggerDirection { get; set; }
        public string blockTradeId { get; set; }
        public string rejectReason { get; set; }
        public string isLeverage { get; set; }
        public string price { get; set; }
        public string orderIv { get; set; }
        public string createdTime { get; set; }
        public string tpTriggerBy { get; set; }
        public int positionIdx { get; set; }
        public string trailingPercentage { get; set; }
        public string timeInForce { get; set; }
        public string leavesValue { get; set; }
        public string basePrice { get; set; }
        public string updatedTime { get; set; }
        public string side { get; set; }
        public int smpGroup { get; set; }
        public string triggerPrice { get; set; }
        public string tpLimitPrice { get; set; }
        public string trailingValue { get; set; }
        public string cumExecFee { get; set; }
        public string slTriggerBy { get; set; }
        public string leavesQty { get; set; }
        public bool closeOnTrigger { get; set; }
        public string placeType { get; set; }
        public string cumExecQty { get; set; }
        public bool reduceOnly { get; set; }
        public string activationPrice { get; set; }
        public string qty { get; set; }
        public string stopLoss {  get; set; }
        public string marketUnit { get; set; }
        public string smpOrderId { get; set; }

        public string triggerBy {  get; set; }
    }

}
