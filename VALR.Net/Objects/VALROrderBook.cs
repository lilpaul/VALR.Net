using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALROrderBook
    {
        public IEnumerable<VALROrderBookItem> Asks { get; set; }
        public IEnumerable<VALROrderBookItem> Bids { get; set; }
    }

    public class VALROrderBookItem
    {
        public TradeSide Side { get; set; } //"sell"
        public decimal Quantity { get; set; } //"0.1"
        public decimal Price { get; set; } //"88000"
        public string CurrencyPair { get; set; } //"BTCZAR"
        public int OrderCount { get; set; } //1
    }
}
