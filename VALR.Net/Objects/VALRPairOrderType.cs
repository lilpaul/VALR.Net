using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRPairOrderType
    {
        public string CurrencyPair { get; set; }
        public OrderType[] OrderTypes { get; set; }
    }
}
