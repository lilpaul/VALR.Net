using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VALR.Net.Interfaces;
using VALR.Net.Objects;

namespace VALR.Net
{
    public class VALRClient : RestClient, IVALRClient
    {
        #region fields
        private static VALRClientOptions defaultOptions = new VALRClientOptions();
        private static VALRClientOptions DefaultOptions => defaultOptions.Copy<VALRClientOptions>();

        private const string ApiVersion1 = "1";

        private const string CurrenciesEndpoint = "public/currencies";
        #endregion

        #region constructor/destructor
        /// <summary>
        /// Create a new instance of BitfinexClient using the default options
        /// </summary>
        public VALRClient() : this(DefaultOptions)
        {
        }

        /// <summary>
        /// Create a new instance of BitfinexClient using provided options
        /// </summary>
        /// <param name="options">The options to use for this client</param>
        public VALRClient(VALRClientOptions options) : base(options, options.ApiCredentials == null ? null : new VALRAuthenticationProvider(options.ApiCredentials))
        {
        }
        #endregion

        #region methods
        #region Version1
        /// <summary>
        /// Gets a list of supported currencies
        /// </summary>
        /// <param name="ct">Cancellation token</param><returns></returns>
        public WebCallResult<IEnumerable<VALRCurrency>> GetCurrencies(CancellationToken ct = default) => GetCurrenciesAsync(ct).Result;

        /// <summary>
        /// Gets a list of supported currencies
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public async Task<WebCallResult<IEnumerable<VALRCurrency>>> GetCurrenciesAsync(CancellationToken ct = default)
        {
            var result = await SendRequest<IEnumerable<VALRCurrency>>(GetUrl(CurrenciesEndpoint, ApiVersion1), HttpMethod.Get, ct).ConfigureAwait(false);
            if (!result)
                return WebCallResult<IEnumerable<VALRCurrency>>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<IEnumerable<VALRCurrency>>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }
        #endregion
        #endregion

        #region private methods
        private Uri GetUrl(string endpoint, string version)
        {
            var result = $"{BaseAddress}/v{version}/{endpoint}";
            return new Uri(result);
        }
        #endregion
    }
}
