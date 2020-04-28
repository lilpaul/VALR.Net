using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
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
        private const string CurrencyPairsEndpoint = "public/pairs";
        private const string PairsOrderTypesEndpoint = "public/ordertypes";
        private const string PairOrderTypesEndpoint = "public/{}/ordertypes";
        private const string MarketSummariesEndpoint = "public/marketsummary";
        private const string MarketSummaryEndpoint = "public/{}/marketsummary";
        private const string BalancesEndpoint = "account/balances";
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
        /// <summary>
        /// Sets the default options to use for new clients
        /// </summary>
        /// <param name="options">The options to use for new clients</param>
        public static void SetDefaultOptions(VALRClientOptions options)
        {
            defaultOptions = options;
        }

        /// <summary>
        /// Set the API key and secret
        /// </summary>
        /// <param name="apiKey">The api key</param>
        /// <param name="apiSecret">The api secret</param>
        public void SetApiCredentials(string apiKey, string apiSecret)
        {
            SetAuthenticationProvider(new VALRAuthenticationProvider(new ApiCredentials(apiKey, apiSecret)));
        }

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

        /// <summary>
        /// Gets a list of supported currency pairs
        /// </summary>
        /// <param name="ct">Cancellation token</param><returns></returns>
        public WebCallResult<IEnumerable<VALRCurrencyPair>> GetCurrencyPairs(CancellationToken ct = default) => GetCurrencyPairsAsync(ct).Result;

        /// <summary>
        /// Gets a list of supported currency pairs
        /// </summary>
        /// <param name="ct">Cancellation token</param><returns></returns>
        public async Task<WebCallResult<IEnumerable<VALRCurrencyPair>>> GetCurrencyPairsAsync(CancellationToken ct = default)
        {
            var result = await SendRequest<IEnumerable<VALRCurrencyPair>>(GetUrl(CurrencyPairsEndpoint, ApiVersion1), HttpMethod.Get, ct).ConfigureAwait(false);
            if (!result)
                return WebCallResult<IEnumerable<VALRCurrencyPair>>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<IEnumerable<VALRCurrencyPair>>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Gets a list of supported order types for each pair
        /// </summary>
        /// <param name="ct">Cancellation token</param><returns></returns>
        public WebCallResult<IEnumerable<VALRPairOrderType>> GetPairOrderTypes(CancellationToken ct = default) => GetPairOrderTypesAsync(ct).Result;

        /// <summary>
        /// Gets a list of supported order types for each pair
        /// </summary>
        /// <param name="ct">Cancellation token</param><returns></returns>
        public async Task<WebCallResult<IEnumerable<VALRPairOrderType>>> GetPairOrderTypesAsync(CancellationToken ct = default)
        {
            var result = await SendRequest<IEnumerable<VALRPairOrderType>>(GetUrl(PairsOrderTypesEndpoint, ApiVersion1), HttpMethod.Get, ct).ConfigureAwait(false);
            if (!result)
                return WebCallResult<IEnumerable<VALRPairOrderType>>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<IEnumerable<VALRPairOrderType>>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }


        /// <summary>
        /// Gets a list of supported order types for a single pair
        /// </summary>
        /// <param name="ct">Cancellation token</param><returns></returns>
        public WebCallResult<IEnumerable<OrderType>> GetPairOrderTypes(string pair, CancellationToken ct = default) => GetPairOrderTypesAsync(pair, ct).Result;

        /// <summary>
        /// Gets a list of supported order types for a single pair
        /// </summary>
        /// <param name="ct">Cancellation token</param><returns></returns>
        public async Task<WebCallResult<IEnumerable<OrderType>>> GetPairOrderTypesAsync(string pair, CancellationToken ct = default)
        {
            var result = await SendRequest<IEnumerable<OrderType>>(GetUrl(FillPathParameter(PairOrderTypesEndpoint, pair), ApiVersion1), HttpMethod.Get, ct).ConfigureAwait(false);
            if (!result)
                return WebCallResult<IEnumerable<OrderType>>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<IEnumerable<OrderType>>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Gets a list of supported order types for each pair
        /// </summary>
        /// <param name="ct">Cancellation token</param><returns></returns>
        public WebCallResult<IEnumerable<VALRMarketSummary>> GetMarketSummary(CancellationToken ct = default) => GetMarketSummaryAsync(ct).Result;

        /// <summary>
        /// Gets a list of supported order types for each pair
        /// </summary>
        /// <param name="ct">Cancellation token</param><returns></returns>
        public async Task<WebCallResult<IEnumerable<VALRMarketSummary>>> GetMarketSummaryAsync(CancellationToken ct = default)
        {
            var result = await SendRequest<IEnumerable<VALRMarketSummary>>(GetUrl(MarketSummariesEndpoint, ApiVersion1), HttpMethod.Get, ct).ConfigureAwait(false);
            if (!result)
                return WebCallResult<IEnumerable<VALRMarketSummary>>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<IEnumerable<VALRMarketSummary>>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Gets a list of supported order types for a single pair
        /// </summary>
        /// <param name="ct">Cancellation token</param><returns></returns>
        public WebCallResult<VALRMarketSummary> GetMarketSummary(string pair, CancellationToken ct = default) => GetMarketSummaryAsync(pair, ct).Result;

        /// <summary>
        /// Gets a list of supported order types for a single pair
        /// </summary>
        /// <param name="ct">Cancellation token</param><returns></returns>
        public async Task<WebCallResult<VALRMarketSummary>> GetMarketSummaryAsync(string pair, CancellationToken ct = default)
        {
            var result = await SendRequest<VALRMarketSummary>(GetUrl(FillPathParameter(MarketSummaryEndpoint, pair), ApiVersion1), HttpMethod.Get, ct).ConfigureAwait(false);
            if (!result)
                return WebCallResult<VALRMarketSummary>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<VALRMarketSummary>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Get all funds
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public WebCallResult<IEnumerable<VALRWallet>> GetBalances(CancellationToken ct = default) => GetBalancesAsync(ct).Result;

        /// <summary>
        /// Get all funds
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public async Task<WebCallResult<IEnumerable<VALRWallet>>> GetBalancesAsync(CancellationToken ct = default)
        {
            var result = await SendRequest<IEnumerable<VALRWallet>>(GetUrl(BalancesEndpoint, ApiVersion1), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<IEnumerable<VALRWallet>>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<IEnumerable<VALRWallet>>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
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
