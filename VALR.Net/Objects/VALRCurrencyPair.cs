using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRCurrencyPair
    {
        public string Symbol { get; set; } //"BTCZAR"
        public string BaseCurrency { get; set; } //"BTC"
        public string QuoteCurrency { get; set; } //"ZAR"
        public string ShortName { get; set; } //"BTC/ZAR"
        public bool Active { get; set; } //true
        public decimal MinBaseAmount { get; set; } //"0.0001"
        public decimal MaxBaseAmount { get; set; } //"2"
        public decimal MinQuoteAmount { get; set; } //"10"
        public decimal MaxQuoteAmount { get; set; } //"100000"
    }
}
