using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRSimpleBuySellQuoteResult
    {
        public string CurrencyPair { get; set; } //"BTCZAR",
        public decimal PayAmount { get; set; } //"0.001"
        public decimal ReceiveAmount { get; set; } //"122.88"
        public decimal Fee { get; set; } //"0.92"
        public string FeeCurrency { get; set; } //"R"
        public DateTime CreatedAt { get; set; } //"2019-05-15T15:04:10.873"
        public string Id { get; set; } //"b6560771-4ee0-4031-bce2-e45adc93b534"
    }
}
