using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRSimpleBuySellOrderStatus
    {
        public string OrderId { get; set; } //"9fed72b4-5d59-4bd7-b4fc-26cf43d27c94"
        public string Success { get; set; } //true
        public string Processing { get; set; } //false
        public string PaidAmount { get; set; } //"0.0008"
        public string PaidCurrency { get; set; } //"BTC"
        public string ReceivedAmount { get; set; } //"54.49553877"
        public string ReceivedCurrency { get; set; } //"ADA"
        public string FeeAmount { get; set; } //"0.000006"
        public string FeeCurrency { get; set; } //"BTC"
        public string OrderExecutedAt { get; set; } //"2019-04-20T13:57:56.618"    
    }
}
