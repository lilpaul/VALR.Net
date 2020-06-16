using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRHistoricalOrderDetail
    {
        public string OrderId { get; set; } //"4ffed821-9352-4dc5-8400-1cfa80006d31"
        public string CustomerOrderId { get; set; } //"2"
        public string OrderStatusType { get; set; } //"Filled"
        public string CurrencyPair { get; set; } //"BTCZAR"
        public decimal OriginalPrice { get; set; } //"50000"
        public decimal RemainingQuantity { get; set; } //"0"
        public decimal OriginalQuantity { get; set; } //"0.1"
        public TradeSide OrderSide { get; set; } //"sell"
        public OrderType OrderType { get; set; } //"limit"
        public string FailedReason { get; set; } //""
        public string OrderUpdatedAt { get; set; } //"2019-05-09T20:24:16.491Z"
        public string OrderCreatedAt { get; set; } //"2019-05-09T20:24:16.487Z"
    }
}
