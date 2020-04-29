using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRDetailedOrderBook
    {
        public IEnumerable<VALRDetailedOrderBookItem> Asks { get; set; }
        public IEnumerable<VALRDetailedOrderBookItem> Bids { get; set; }
    }

    public class VALRDetailedOrderBookItem
    {
        public TradeSide Side { get; set; } //"sell"
        public decimal Quantity { get; set; } //"0.00364729"
        public decimal Price { get; set; } //"160000"
        public string CurrencyPair { get; set; } //"BTCZAR"
        public string Id { get; set; } //"0ed9f7f6-1aa5-4d5b-840d-9d2b9590edab"
        public int PositionAtPrice { get; set; } //1
    }
}
