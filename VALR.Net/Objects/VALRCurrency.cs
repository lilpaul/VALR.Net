using CryptoExchange.Net.Converters;
using Newtonsoft.Json;

namespace VALR.Net.Objects
{
    /// <summary>
    /// Currency info
    /// </summary>
    public class VALRCurrency
    {
        /// <summary>
        /// The symbol of the currency
        /// </summary>
        public string Symbol { get; set; } = "";
        /// <summary>
        /// The full name of the currency
        /// </summary>
        public bool IsActive { get; set; } = false;
        /// <summary>
        /// The short name / code of the currency
        /// </summary>
        public string ShortName { get; set; } = "";
        /// <summary>
        /// The name of the currency
        /// </summary>
        public string LongName { get; set; } = "";
    }
}
