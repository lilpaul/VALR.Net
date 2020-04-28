using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRWallet
    {
        public string Currency { get; set; }
        public decimal Available { get; set; }
        public decimal Reserved { get; set; }
        public decimal Total { get; set; }
    }
}
