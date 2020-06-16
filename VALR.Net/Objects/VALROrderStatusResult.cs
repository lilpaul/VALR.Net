using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALROrderStatusResult
    {
        public string OrderId { get; set; } //"38511e49-a755-4f8f-a2b1-232bae6967dc"
        public string OrderStatusType { get; set; } //"Placed"
        public string CurrencyPair { get; set; } //"BTCZAR"
        public decimal OriginalPrice { get; set; } //"10000"
        public decimal RemainingQuantity { get; set; } //"0.1"
        public decimal OriginalQuantity { get; set; } //"0.1"
        public TradeSide OrderSide { get; set; } //"sell"
        public string OrderType { get; set; } //"post-only limit"
        public string FailedReason { get; set; } //""
        public string CustomerOrderId { get; set; } //"1234"
        public DateTime OrderUpdatedAt { get; set; } //"2019-04-17T19:51:35.778Z"
        public DateTime OrderCreatedAt { get; set; } //"2019-04-17T19:51:35.776Z"
    }
}
