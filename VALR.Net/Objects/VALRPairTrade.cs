using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRPairTrade
    {
        public decimal Price { get; set; } //"80000"
        public decimal Quantity { get; set; } //0.09830742"
        public string CurrencyPair { get; set; } //BTCZAR
        public DateTime TradedAt { get; set; } //2019-05-09T20:24:16.491Z
        public TradeSide Side { get; set; } //"sell"
        public int TradeId { get; set; } //10632
    }
}
