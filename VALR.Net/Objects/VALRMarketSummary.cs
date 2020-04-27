using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRMarketSummary
    {
        public string CurrencyPair { get; set; } //"BTCZAR"
        public decimal AskPrice { get; set; } //"10000"
        public decimal BidPrice { get; set; } //"7005"
        public decimal LastTradedPrice { get; set; } //"7005"
        public decimal PreviousClosePrice { get; set; } //"7005"
        public decimal BaseVolume { get; set; } //"0.16065663"
        public decimal HighPrice { get; set; } //"10000"
        public decimal LowPrice { get; set; } //"7005"
        public DateTime Created { get; set; } //"2019-04-20T13:02:03.228Z"
        public decimal ChangeFromPrevious { get; set; } //"0"
    }
}
