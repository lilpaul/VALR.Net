using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRHistoricalOrder
    {
        public string OrderId { get; set; } //"4ffed821-9352-4dc5-8400-1cfa80006d31"
        public string CustomerOrderId { get; set; } //"2"
        public string OrderStatusType { get; set; } //"Filled"
        public string CurrencyPair { get; set; } //"BTCZAR"
        public string AveragePrice { get; set; } //"80033.85"
        public string OriginalPrice { get; set; } //"50000"
        public string Quantity { get; set; } //"0"
        public string OriginalQuantity { get; set; } //"0.1"
        public string Total { get; set; } //"8003.38"
        public string TotalFee { get; set; } //"16"
        public string OrderSide { get; set; } //"sell"
        public string OrderType { get; set; } //"limit"
        public string FailedReason { get; set; } //""
        public string OrderUpdatedAt { get; set; } //"2019-05-09T20:24:16.491Z"
        public string OrderCreatedAt { get; set; } //"2019-05-09T20:24:16.487Z"
    }
}
