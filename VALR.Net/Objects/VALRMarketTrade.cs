using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRMarketTrade
    {
        public decimal Price { get; set; } //"111000"
        public decimal Quantity { get; set; } //"0.0078218"
        public string CurrencyPair { get; set; } //"BTCZAR"
        public DateTime TradedAt { get; set; } //"2019-06-14T08:01:59.679Z"
        public TradeSide TakerSide { get; set; } //"sell"
        public int SequenceId { get; set; } //11099
        public string Id { get; set; } //"9722a0e6-50e0-4ef4-bc32-c480d73c24db"
    }
}
