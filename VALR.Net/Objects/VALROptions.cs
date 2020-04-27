using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRClientOptions : RestClientOptions
    {
        /// <summary>
        /// Create new client options
        /// </summary>
        public VALRClientOptions() : base("https://api.valr.com")
        {
        }
    }
}
