using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APISandbox.Models
{
    public class BitMexInstrumentList
    {
        [JsonPropertyName("symbol")] public string symbol { get; set; }
        [JsonPropertyName("rootSymbol")] public string rootSymbol { get; set; }
        [JsonPropertyName("state")] public string state { get; set; }
        [JsonPropertyName("typ")] public string typ { get; set; }
        [JsonPropertyName("listing")] public DateTime listing { get; set; }
        [JsonPropertyName("front")] public DateTime front { get; set; }
        [JsonPropertyName("positionCurrency")] public string positionCurrency { get; set; }
        [JsonPropertyName("underlying")] public string underlying { get; set; }
        [JsonPropertyName("quoteCurrency")] public string quoteCurrency { get; set; }
        [JsonPropertyName("underlyingSymbol")] public string underlyingSymbol { get; set; }
        [JsonPropertyName("reference")] public string reference { get; set; }
        [JsonPropertyName("referenceSymbol")] public string referenceSymbol { get; set; }
        [JsonPropertyName("maxOrderQty")] public long maxOrderQty { get; set; }
        [JsonPropertyName("maxPrice")] public double maxPrice { get; set; }
        [JsonPropertyName("lotSize")] public int lotSize { get; set; }
        [JsonPropertyName("tickSize")] public double tickSize { get; set; }
        [JsonPropertyName("multiplier")] public int multiplier { get; set; }
        [JsonPropertyName("settlCurrency")] public string settlCurrency { get; set; }
        [JsonPropertyName("underlyingToPositionMultiplier")] public int underlyingToPositionMultiplier { get; set; }
        [JsonPropertyName("quoteToSettleMultiplier")] public int quoteToSettleMultiplier { get; set; }
        [JsonPropertyName("isQuanto")] public bool isQuanto { get; set; }
        [JsonPropertyName("isInverse")] public bool isInverse { get; set; }
        [JsonPropertyName("initMargin")] public double initMargin { get; set; }
        [JsonPropertyName("maintMargin")] public double maintMargin { get; set; }
        [JsonPropertyName("riskLimit")] public long riskLimit { get; set; }
        [JsonPropertyName("riskStep")] public long riskStep { get; set; }
        [JsonPropertyName("taxed")] public bool taxed { get; set; }
        [JsonPropertyName("deleverage")] public bool deleverage { get; set; }
        [JsonPropertyName("makerFee")] public double makerFee { get; set; }
        [JsonPropertyName("takerFee")] public double takerFee { get; set; }
        [JsonPropertyName("settlementFee")] public double settlementFee { get; set; }
        [JsonPropertyName("fundingBaseSymbol")] public string fundingBaseSymbol { get; set; }
        [JsonPropertyName("fundingQuoteSymbol")] public string fundingQuoteSymbol { get; set; }
        [JsonPropertyName("fundingPremiumSymbol")] public string fundingPremiumSymbol { get; set; }
        [JsonPropertyName("fundingTimestamp")] public DateTime fundingTimestamp { get; set; }
        [JsonPropertyName("fundingInterval")] public DateTime fundingInterval { get; set; }
        [JsonPropertyName("fundingRate")] public double fundingRate { get; set; }
        [JsonPropertyName("indicativeFundingRate")] public double indicativeFundingRate { get; set; }
        [JsonPropertyName("prevClosePrice")] public double prevClosePrice { get; set; }
        [JsonPropertyName("limitDownPrice")] public double? limitDownPrice { get; set; }
        [JsonPropertyName("limitUpPrice")] public double? limitUpPrice { get; set; }
        [JsonPropertyName("prevTotalVolume")] public long prevTotalVolume { get; set; }
        [JsonPropertyName("totalVolume")] public long totalVolume { get; set; }
        [JsonPropertyName("volume")] public long volume { get; set; }
        [JsonPropertyName("volume24h")] public long volume24h { get; set; }
        [JsonPropertyName("prevTotalTurnover")] public long prevTotalTurnover { get; set; }
        [JsonPropertyName("totalTurnover")] public long totalTurnover { get; set; }
        [JsonPropertyName("turnover")] public long turnover { get; set; }
        [JsonPropertyName("turnover24h")] public long turnover24h { get; set; }
        [JsonPropertyName("homeNotional24h")] public double homeNotional24h { get; set; }
        [JsonPropertyName("foreignNotional24h")] public double foreignNotional24h { get; set; }
        [JsonPropertyName("prevPrice24h")] public double prevPrice24h { get; set; }
        [JsonPropertyName("vwap")] public double vwap { get; set; }
        [JsonPropertyName("highPrice")] public double highPrice { get; set; }
        [JsonPropertyName("lowPrice")] public double lowPrice { get; set; }
        [JsonPropertyName("lastPrice")] public double lastPrice { get; set; }
        [JsonPropertyName("lastPriceProtected")] public double lastPriceProtected { get; set; }
        [JsonPropertyName("lastTickDirection")] public string lastTickDirection { get; set; }
        [JsonPropertyName("lastChangePcnt")] public double lastChangePcnt { get; set; }
        [JsonPropertyName("bidPrice")] public double bidPrice { get; set; }
        [JsonPropertyName("midPrice")] public double midPrice { get; set; }
        [JsonPropertyName("askPrice")] public double askPrice { get; set; }
        [JsonPropertyName("impactBidPrice")] public double impactBidPrice { get; set; }
        [JsonPropertyName("impactMidPrice")] public double impactMidPrice { get; set; }
        [JsonPropertyName("impactAskPrice")] public double impactAskPrice { get; set; }
        [JsonPropertyName("hasLiquidity")] public bool hasLiquidity { get; set; }
        [JsonPropertyName("openInterest")] public long openInterest { get; set; }
        [JsonPropertyName("openValue")] public long openValue { get; set; }
        [JsonPropertyName("fairMethod")] public string fairMethod { get; set; }
        [JsonPropertyName("fairBasisRate")] public double fairBasisRate { get; set; }
        [JsonPropertyName("fairBasis")] public double fairBasis { get; set; }
        [JsonPropertyName("fairPrice")] public double fairPrice { get; set; }
        [JsonPropertyName("markMethod")] public string markMethod { get; set; }
        [JsonPropertyName("markPrice")] public double markPrice { get; set; }
        [JsonPropertyName("indicativeSettlePrice")] public double indicativeSettlePrice { get; set; }
        [JsonPropertyName("instantPnl")] public bool instantPnl { get; set; }
        [JsonPropertyName("timestamp")] public DateTime timestamp { get; set; }
        [JsonPropertyName("minTick")] public double minTick { get; set; }
        [JsonPropertyName("fundingBaseRate")] public double fundingBaseRate { get; set; }
        [JsonPropertyName("fundingQuoteRate")] public double fundingQuoteRate { get; set; }
        [JsonPropertyName("capped")] public bool capped { get; set; }
    }
}
