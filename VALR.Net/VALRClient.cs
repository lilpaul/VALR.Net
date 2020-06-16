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
        private const string TransactionHistoryEndpoint = "account/transactionhistory?skip={}&limit={}";
        private const string TradeHistoryEndpoint = "account/{}/tradehistory?limit={}";
        private const string DepositAddressEndpoint = "wallet/crypto/{}/deposit/address";
        private const string WithdrawalInfoEndpoint = "wallet/crypto/{}/withdraw";
        private const string WithdrawCryptoEndpoint = "wallet/crypto/{}/withdraw";
        private const string WithdrawalStatusEndpoint = "wallet/crypto/{}/withdraw/{}";
        private const string DepositHistoryEndpoint = "wallet/crypto/{}/deposit/history?skip={}&limit={}";
        private const string WithdrawalHistoryEndpoint = "wallet/crypto/{}/withdraw/history?skip={}&limit={}";
        private const string BankAccountsEndpoint = "wallet/fiat/{}/accounts";
        private const string WithdrawFiatEndpoint = "wallet/fiat/{}/withdraw";
        private const string OrderBookEndpoint = "marketdata/{}/orderbook";
        private const string DetailedOrderBookEndpoint = "marketdata/{}/orderbook/full";
        private const string MarketTradeHistoryEndpoint = "marketdata/{}/tradehistory?limit={}";
        private const string SimpleBuySellQuoteEndpoint = "simple/{}/quote";
        private const string SimpleBuySellOrderEndpoint = "simple/{}/order";
        private const string SimpleBuySellOrderStatusEndpoint = "simple/{}/order/{}";
        private const string LimitOrderEndpoint = "orders/limit";
        private const string MarketOrderEndpoint = "orders/market";
        private const string OrderStatusByOrderIdEndpoint = "orders/{}/orderid/{}";
        private const string OrderStatusByCustomerOrderIdEndpoint = "orders/{}/customerorderid/{}";
        private const string AllOpenOrdersEndpoint = "orders/open";
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
        /// <param name="pair">Trading pair eg. "BTCZAR"</param><returns></returns>
        /// <param name="ct">Cancellation token</param><returns></returns>
        public WebCallResult<IEnumerable<OrderType>> GetPairOrderTypes(string pair, CancellationToken ct = default) => GetPairOrderTypesAsync(pair, ct).Result;

        /// <summary>
        /// Gets a list of supported order types for a single pair
        /// </summary>
        /// <param name="pair">Trading pair eg. "BTCZAR"</param><returns></returns>
        /// <param name="ct">Cancellation token</param><returns></returns>
        public async Task<WebCallResult<IEnumerable<OrderType>>> GetPairOrderTypesAsync(string pair, CancellationToken ct = default)
        {
            var result = await SendRequest<IEnumerable<OrderType>>(GetUrl(FillPathParameter(PairOrderTypesEndpoint, pair), ApiVersion1), HttpMethod.Get, ct).ConfigureAwait(false);
            if (!result)
                return WebCallResult<IEnumerable<OrderType>>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<IEnumerable<OrderType>>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Gets a list of all market summaries
        /// </summary>
        /// <param name="ct">Cancellation token</param><returns></returns>
        public WebCallResult<IEnumerable<VALRMarketSummary>> GetMarketSummary(CancellationToken ct = default) => GetMarketSummaryAsync(ct).Result;

        /// <summary>
        /// Gets a list of all market summaries
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
        /// Gets a market summary for a single pair
        /// </summary>
        /// <param name="pair">Trading pair eg. "BTCZAR"</param><returns></returns>
        /// <param name="ct">Cancellation token</param><returns></returns>
        public WebCallResult<VALRMarketSummary> GetMarketSummary(string pair, CancellationToken ct = default) => GetMarketSummaryAsync(pair, ct).Result;

        /// <summary>
        /// Gets a market summary for a single pair
        /// </summary>
        /// <param name="pair">Trading pair eg. "BTCZAR"</param><returns></returns>
        /// <param name="ct">Cancellation token</param><returns></returns>
        public async Task<WebCallResult<VALRMarketSummary>> GetMarketSummaryAsync(string pair, CancellationToken ct = default)
        {
            var result = await SendRequest<VALRMarketSummary>(GetUrl(FillPathParameter(MarketSummaryEndpoint, pair), ApiVersion1), HttpMethod.Get, ct).ConfigureAwait(false);
            if (!result)
                return WebCallResult<VALRMarketSummary>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<VALRMarketSummary>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Get all account balances
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public WebCallResult<IEnumerable<VALRWallet>> GetBalances(CancellationToken ct = default) => GetBalancesAsync(ct).Result;

        /// <summary>
        /// Get all account balances
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

        /// <summary>
        /// Get transactions from account history
        /// </summary>
        /// <param name="skip">Number of records to skip (pagination)</param><returns></returns>
        /// <param name="limit">Number of records to fetch (pagination)</param><returns></returns>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public WebCallResult<IEnumerable<VALRTransaction>> GetTransactionHistory(int skip = 0, int limit = 100, CancellationToken ct = default) => GetTransactionHistoryAsync(skip, limit, ct).Result;

        /// <summary>
        /// Get transactions from account history
        /// </summary>
        /// <param name="skip">Number of records to skip (pagination)</param><returns></returns>
        /// <param name="limit">Number of records to fetch (pagination)</param><returns></returns>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public async Task<WebCallResult<IEnumerable<VALRTransaction>>> GetTransactionHistoryAsync(int skip = 0, int limit = 100, CancellationToken ct = default)
        {
            var result = await SendRequest<IEnumerable<VALRTransaction>>(GetUrl(FillPathParameter(TransactionHistoryEndpoint, skip.ToString(), limit.ToString()), ApiVersion1), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<IEnumerable<VALRTransaction>>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<IEnumerable<VALRTransaction>>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Get recent account trade history for a specific trading pair
        /// </summary>
        /// <param name="pair">Trading pair eg. "BTCZAR"</param><returns></returns>
        /// <param name="limit">Number of records to fetch (100 max)</param><returns></returns>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public WebCallResult<IEnumerable<VALRPairTrade>> GetTradeHistory(string pair, int limit = 100, CancellationToken ct = default) => GetTradeHistoryAsync(pair, limit, ct).Result;

        /// <summary>
        /// Get recent account trade history for a specific trading pair
        /// </summary>
        /// <param name="pair">Trading pair eg. "BTCZAR"</param><returns></returns>
        /// <param name="limit">Number of records to fetch (100 max)</param><returns></returns>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public async Task<WebCallResult<IEnumerable<VALRPairTrade>>> GetTradeHistoryAsync(string pair, int limit = 100, CancellationToken ct = default)
        {
            var result = await SendRequest<IEnumerable<VALRPairTrade>>(GetUrl(FillPathParameter(TradeHistoryEndpoint, pair, limit.ToString()), ApiVersion1), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<IEnumerable<VALRPairTrade>>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<IEnumerable<VALRPairTrade>>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Returns the default deposit address associated with currency specified
        /// </summary>
        /// <param name="currency">Crypto currency code eg. "ETH"</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public WebCallResult<VALRDepositAddress> GetDepositAddress(string currency, CancellationToken ct = default) => GetDepositAddressAsync(currency, ct).Result;

        /// <summary>
        /// Returns the default deposit address associated with currency specified
        /// </summary>
        /// <param name="currency">Crypto currency code eg. "ETH"</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public async Task<WebCallResult<VALRDepositAddress>> GetDepositAddressAsync(string currency, CancellationToken ct = default)
        {
            var result = await SendRequest<VALRDepositAddress>(GetUrl(FillPathParameter(DepositAddressEndpoint, currency), ApiVersion1), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<VALRDepositAddress>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<VALRDepositAddress>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Get all the information about withdrawing a given currency from your VALR account. 
        /// That will include withdrawal costs, minimum withdrawal amount etc.
        /// </summary>
        /// <param name="currency">Currency code eg. "ETH"</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public WebCallResult<VALRWithdrawalInfo> GetWithdrawalInfo(string currency, CancellationToken ct = default) => GetCryptoDepositAddressAsync(currency, ct).Result;

        /// <summary>
        /// Get all the information about withdrawing a given currency from your VALR account. 
        /// That will include withdrawal costs, minimum withdrawal amount etc.
        /// </summary>
        /// <param name="currency">Currency code eg. "ETH"</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public async Task<WebCallResult<VALRWithdrawalInfo>> GetCryptoDepositAddressAsync(string currency, CancellationToken ct = default)
        {
            var result = await SendRequest<VALRWithdrawalInfo>(GetUrl(FillPathParameter(WithdrawalInfoEndpoint, currency), ApiVersion1), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<VALRWithdrawalInfo>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<VALRWithdrawalInfo>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Withdraw cryptocurrency funds to an address
        /// </summary>
        /// <param name="currencyCode">The currency to withdraw funds </param>
        /// <param name="amount">The amount to of funds to withdraw</param>
        /// <param name="address">The address to send the funds to</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The average price at which the execution would happen</returns>
        public WebCallResult<VALRWithdrawalResult> WithdrawCrypto(string currencyCode, decimal amount, string address, CancellationToken ct = default)
            => WithdrawCryptoAsync(currencyCode, amount, address, ct).Result;

        /// <summary>
        /// Withdraw cryptocurrency funds to an address
        /// </summary>
        /// <param name="currencyCode">The currency to withdraw funds </param>
        /// <param name="amount">The amount to of funds to withdraw</param>
        /// <param name="address">The address to send the funds to</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>The average price at which the execution would happen</returns>
        public async Task<WebCallResult<VALRWithdrawalResult>> WithdrawCryptoAsync(string currencyCode, decimal amount, string address, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "amount", amount },
                { "address", address }
            };

            //TODO: Keeps complaining about invalid signature even though authenticator signing test passes???
            var result = await SendRequest<VALRWithdrawalResult>(GetUrl(FillPathParameter(WithdrawCryptoEndpoint, currencyCode), ApiVersion1), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<VALRWithdrawalResult>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<VALRWithdrawalResult>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Check the status of a withdrawal.
        /// </summary>
        /// <param name="currencyCode">This is the currency code for the currency you have withdrawn. Examples: BTC, ETH, XRP, ADA, etc.</param><returns></returns>
        /// <param name="withdrawId">The unique id that represents your withdrawal request. This is provided as a response to the API call to withdraw.</param><returns></returns>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public WebCallResult<VALRWithdrawalStatus> GetWithdrawalStatus(string currencyCode, string withdrawId, CancellationToken ct = default) => GetWithdrawalStatusAsync(currencyCode, withdrawId, ct).Result;

        /// <summary>
        /// Check the status of a withdrawal.
        /// </summary>
        /// <param name="currencyCode">This is the currency code for the currency you have withdrawn. Examples: BTC, ETH, XRP, ADA, etc.</param><returns></returns>
        /// <param name="withdrawId">The unique id that represents your withdrawal request. This is provided as a response to the API call to withdraw.</param><returns></returns>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public async Task<WebCallResult<VALRWithdrawalStatus>> GetWithdrawalStatusAsync(string currencyCode, string withdrawId, CancellationToken ct = default)
        {
            //TODO: Test after the withdraw crypto method is working so you have a withdrawal id to use for testing
            var result = await SendRequest<VALRWithdrawalStatus>(GetUrl(FillPathParameter(TradeHistoryEndpoint, currencyCode, withdrawId), ApiVersion1), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<VALRWithdrawalStatus>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<VALRWithdrawalStatus>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Get the Deposit History records for a given currency.
        /// </summary>
        /// <param name="currencyCode">Currently, the allowed values here are BTC, ETH, XRP</param>
        /// <param name="skip">Skip number of items from the list.</param>
        /// <param name="limit">Limit the number of items returned.</param>
        /// <returns></returns>
        public WebCallResult<IEnumerable<VALRDeposit>> GetDepositHistory(string currencyCode, int skip = 0, int limit = 100, CancellationToken ct = default) => GetDepositHistoryAsync(currencyCode, skip, limit, ct).Result;

        /// <summary>
        /// Get the Deposit History records for a given currency.
        /// </summary>
        /// <param name="currencyCode">Currently, the allowed values here are BTC, ETH, XRP</param>
        /// <param name="skip">Skip number of items from the list.</param>
        /// <param name="limit">Limit the number of items returned.</param>
        /// <returns></returns>
        public async Task<WebCallResult<IEnumerable<VALRDeposit>>> GetDepositHistoryAsync(string currencyCode, int skip = 0, int limit = 100, CancellationToken ct = default)
        {
            var result = await SendRequest<IEnumerable<VALRDeposit>>(GetUrl(FillPathParameter(DepositHistoryEndpoint, currencyCode, skip.ToString(), limit.ToString()), ApiVersion1), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<IEnumerable<VALRDeposit>>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<IEnumerable<VALRDeposit>>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Get the Withdrawal History records for a given currency.
        /// </summary>
        /// <param name="currencyCode">Currently, the allowed values here are BTC, ETH, XRP</param>
        /// <param name="skip">Skip number of items from the list.</param>
        /// <param name="limit">Limit the number of items returned.</param>
        /// <returns></returns>
        public WebCallResult<IEnumerable<VALRWithdrawal>> GetWithdrawalHistory(string currencyCode, int skip = 0, int limit = 100, CancellationToken ct = default) => GetWithdrawalHistoryAsync(currencyCode, skip, limit, ct).Result;

        /// <summary>
        /// Get the Withdrawal History records for a given currency.
        /// </summary>
        /// <param name="currencyCode">Currently, the allowed values here are BTC, ETH, XRP</param>
        /// <param name="skip">Skip number of items from the list.</param>
        /// <param name="limit">Limit the number of items returned.</param>
        /// <returns></returns>
        public async Task<WebCallResult<IEnumerable<VALRWithdrawal>>> GetWithdrawalHistoryAsync(string currencyCode, int skip = 0, int limit = 100, CancellationToken ct = default)
        {
            var result = await SendRequest<IEnumerable<VALRWithdrawal>>(GetUrl(FillPathParameter(WithdrawalHistoryEndpoint, currencyCode, skip.ToString(), limit.ToString()), ApiVersion1), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<IEnumerable<VALRWithdrawal>>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<IEnumerable<VALRWithdrawal>>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Get a list of bank accounts that are linked to your VALR account. Bank accounts can be linked by signing in to your account on www.VALR.com.
        /// </summary>
        /// <param name="currencyCode">The currency code for the fiat currency. Supported: ZAR.</param>
        /// <returns></returns>
        public WebCallResult<IEnumerable<VALRBankAccount>> GetBankAccounts(string currencyCode, CancellationToken ct = default) => GetBankAccountsAsync(currencyCode, ct).Result;

        /// <summary>
        /// Get a list of bank accounts that are linked to your VALR account. Bank accounts can be linked by signing in to your account on www.VALR.com.
        /// </summary>
        /// <param name="currencyCode">The currency code for the fiat currency. Supported: ZAR.</param>
        /// <returns></returns>
        public async Task<WebCallResult<IEnumerable<VALRBankAccount>>> GetBankAccountsAsync(string currencyCode, CancellationToken ct = default)
        {
            var result = await SendRequest<IEnumerable<VALRBankAccount>>(GetUrl(FillPathParameter(BankAccountsEndpoint, currencyCode), ApiVersion1), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<IEnumerable<VALRBankAccount>>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<IEnumerable<VALRBankAccount>>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Withdraw your ZAR funds into one of your linked bank accounts.
        /// The request body accepts an optional field called "fast". If the value of this field is "true" the withdrawal will be processed with real-time clearing during our next withdrawal run.
        /// Please note that higher fees apply to fast withdrawals and some banks do not participate.
        /// </summary>
        /// <param name="currencyCode">The currency code for the fiat currency. Supported: ZAR.</param>
        /// <param name="linkedBankAccountId">The amount to of funds to withdraw</param>
        /// <param name="amount">The address to send the funds to</param>
        /// <param name="fast">The address to send the funds to</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public WebCallResult<VALRWithdrawalResult> WithdrawFiat(string currencyCode, string linkedBankAccountId, decimal amount, bool fast, CancellationToken ct = default)
            => WithdrawFiatAsync(currencyCode, linkedBankAccountId, amount, fast, ct).Result;

        /// <summary>
        /// Withdraw your ZAR funds into one of your linked bank accounts.
        /// The request body accepts an optional field called "fast". If the value of this field is "true" the withdrawal will be processed with real-time clearing during our next withdrawal run.
        /// Please note that higher fees apply to fast withdrawals and some banks do not participate.
        /// </summary>
        /// <param name="currencyCode">The currency code for the fiat currency. Supported: ZAR.</param>
        /// <param name="linkedBankAccountId">The amount to of funds to withdraw</param>
        /// <param name="amount">The address to send the funds to</param>
        /// <param name="fast">The address to send the funds to</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public async Task<WebCallResult<VALRWithdrawalResult>> WithdrawFiatAsync(string currencyCode, string linkedBankAccountId, decimal amount, bool fast, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "linkedBankAccountId", linkedBankAccountId },
                { "amount", amount },
                { "fast", fast }
            };

            //TODO: Keeps complaining about invalid signature even though authenticator signing test passes???
            var result = await SendRequest<VALRWithdrawalResult>(GetUrl(FillPathParameter(WithdrawFiatEndpoint, currencyCode), ApiVersion1), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<VALRWithdrawalResult>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<VALRWithdrawalResult>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Returns a list of the top 20 bids and asks in the order book. Ask orders are sorted by price ascending. Bid orders are sorted by price descending. Orders of the same price are aggregated.
        /// </summary>
        /// <param name="currencyPair">Currency pair for which you want to query the order book. Supported currency pairs: BTCZAR, ETHZAR, XRPZAR</param>
        /// <returns></returns>
        public WebCallResult<VALROrderBook> GetOrderBook(string currencyPair, CancellationToken ct = default) => GetOrderBookAsync(currencyPair, ct).Result;

        /// <summary>
        /// Returns a list of the top 20 bids and asks in the order book. Ask orders are sorted by price ascending. Bid orders are sorted by price descending. Orders of the same price are aggregated.
        /// </summary>
        /// <param name="currencyPair">Currency pair for which you want to query the order book. Supported currency pairs: BTCZAR, ETHZAR, XRPZAR</param>
        /// <returns></returns>
        public async Task<WebCallResult<VALROrderBook>> GetOrderBookAsync(string currencyCode, CancellationToken ct = default)
        {
            var result = await SendRequest<VALROrderBook>(GetUrl(FillPathParameter(OrderBookEndpoint, currencyCode), ApiVersion1), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<VALROrderBook>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<VALROrderBook>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Returns a list of all the bids and asks in the order book. Ask orders are sorted by price ascending. Bid orders are sorted by price descending. Orders of the same price are NOT aggregated.
        /// </summary>
        /// <param name="currencyPair">Currency pair for which you want to query the order book. Supported currency pairs: BTCZAR, ETHZAR, XRPZAR</param>
        /// <returns></returns>
        public WebCallResult<VALRDetailedOrderBook> GetDetailedOrderBook(string currencyPair, CancellationToken ct = default) => GetDetailedOrderBookAsync(currencyPair, ct).Result;

        /// <summary>
        /// Returns a list of all the bids and asks in the order book. Ask orders are sorted by price ascending. Bid orders are sorted by price descending. Orders of the same price are NOT aggregated.
        /// </summary>
        /// <param name="currencyPair">Currency pair for which you want to query the order book. Supported currency pairs: BTCZAR, ETHZAR, XRPZAR</param>
        /// <returns></returns>
        public async Task<WebCallResult<VALRDetailedOrderBook>> GetDetailedOrderBookAsync(string currencyCode, CancellationToken ct = default)
        {
            var result = await SendRequest<VALRDetailedOrderBook>(GetUrl(FillPathParameter(DetailedOrderBookEndpoint, currencyCode), ApiVersion1), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<VALRDetailedOrderBook>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<VALRDetailedOrderBook>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Get the last 100 recent trades for a given currency pair. You can limit the number of trades returned by specifying the limit parameter.
        /// </summary>
        /// <param name="currencyPair">Currency pair for which you want to query the trade history. Supported currency pairs: BTCZAR, ETHZAR, XRPZAR</param>
        /// <param name="limit">Limit the number of items returned.</param>
        /// <returns></returns>
        public WebCallResult<IEnumerable<VALRMarketTrade>> GetMarketTradeHistory(string currencyPair, int limit = 100, CancellationToken ct = default) => GetMarketTradeHistoryAsync(currencyPair, limit, ct).Result;

        /// <summary>
        /// Get the last 100 recent trades for a given currency pair. You can limit the number of trades returned by specifying the limit parameter.
        /// </summary>
        /// <param name="currencyPair">Currency pair for which you want to query the trade history. Supported currency pairs: BTCZAR, ETHZAR, XRPZAR</param>
        /// <param name="limit">Limit the number of items returned.</param>
        /// <returns></returns>
        public async Task<WebCallResult<IEnumerable<VALRMarketTrade>>> GetMarketTradeHistoryAsync(string currencyPair, int limit = 100, CancellationToken ct = default)
        {
            var result = await SendRequest<IEnumerable<VALRMarketTrade>>(GetUrl(FillPathParameter(MarketTradeHistoryEndpoint, currencyPair, limit.ToString()), ApiVersion1), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<IEnumerable<VALRMarketTrade>>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<IEnumerable<VALRMarketTrade>>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Make use of our powerful Simple Buy/Sell API to instantly buy and sell currencies. 
        /// If you want to sell BTC for ZAR, payInCurrency will be BTC and the side would be SELL
        /// If you want to buy BTC with ZAR, payInCurrency will be ZAR and the side would be BUY
        /// </summary>
        /// <param name="currencyPair">The currency pair to trade in</param>
        /// <param name="payInCurrency">The currency code you are paying in.</param>
        /// <param name="payAmount">The amount of crypto to buy/sell</param>
        /// <param name="side">Whether you are buying or selling</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public WebCallResult<VALRSimpleBuySellQuoteResult> SimpleBuySellQuote(string currencyPair, string payInCurrency, decimal payAmount, TradeSide side, CancellationToken ct = default)
            => SimpleBuySellQuoteAsync(currencyPair, payInCurrency, payAmount, side, ct).Result;

        /// <summary>
        /// Make use of our powerful Simple Buy/Sell API to instantly buy and sell currencies. 
        /// If you want to sell BTC for ZAR, payInCurrency will be BTC and the side would be SELL
        /// If you want to buy BTC with ZAR, payInCurrency will be ZAR and the side would be BUY
        /// </summary>
        /// <param name="currencyPair">The currency pair to trade in</param>
        /// <param name="payInCurrency">The currency code you are paying in.</param>
        /// <param name="payAmount">The amount of crypto to buy/sell</param>
        /// <param name="side">Whether you are buying or selling</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public async Task<WebCallResult<VALRSimpleBuySellQuoteResult>> SimpleBuySellQuoteAsync(string currencyPair, string payInCurrency, decimal payAmount, TradeSide side, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "payInCurrency", payInCurrency },
                { "payAmount", payAmount },
                { "side", side.ToString() }
            };

            //TODO: Keeps complaining about invalid signature even though authenticator signing test passes???
            var result = await SendRequest<VALRSimpleBuySellQuoteResult>(GetUrl(FillPathParameter(SimpleBuySellQuoteEndpoint, currencyPair), ApiVersion1), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<VALRSimpleBuySellQuoteResult>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<VALRSimpleBuySellQuoteResult>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Submit an order to buy or sell instantly using Simple Buy/Sell.
        /// </summary>
        /// <param name="currencyPair">The currency pair to trade in</param>
        /// <param name="payInCurrency">The currency code you are paying in.</param>
        /// <param name="payAmount">The amount of crypto to buy/sell</param>
        /// <param name="side">Whether you are buying or selling</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public WebCallResult<VALRCodeMessageResult> SimpleBuySellOrder(string currencyPair, string payInCurrency, decimal payAmount, TradeSide side, CancellationToken ct = default)
            => SimpleBuySellOrderAsync(currencyPair, payInCurrency, payAmount, side, ct).Result;

        /// <summary>
        /// Submit an order to buy or sell instantly using Simple Buy/Sell.
        /// </summary>
        /// <param name="currencyPair">The currency pair to trade in</param>
        /// <param name="payInCurrency">The currency code you are paying in.</param>
        /// <param name="payAmount">The amount of crypto to buy/sell</param>
        /// <param name="side">Whether you are buying or selling</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public async Task<WebCallResult<VALRCodeMessageResult>> SimpleBuySellOrderAsync(string currencyPair, string payInCurrency, decimal payAmount, TradeSide side, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "payInCurrency", payInCurrency },
                { "payAmount", payAmount },
                { "side", side.ToString() }
            };

            //TODO: Keeps complaining about invalid signature even though authenticator signing test passes???
            var result = await SendRequest<VALRCodeMessageResult>(GetUrl(FillPathParameter(SimpleBuySellOrderEndpoint, currencyPair), ApiVersion1), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<VALRCodeMessageResult>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<VALRCodeMessageResult>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Get the status of a Simple Buy/Sell order.
        /// </summary>
        /// <param name="currencyPair">The currency pair to trade in</param>
        /// <param name="orderId">The Id of the order to check status for</param>
        /// <returns></returns>
        public WebCallResult<VALRSimpleBuySellOrderStatus> SimpleBuySellOrderStatus(string currencyPair, string orderId, CancellationToken ct = default) => SimpleBuySellOrderStatusAsync(currencyPair, orderId, ct).Result;

        /// <summary>
        /// Get the status of a Simple Buy/Sell order.
        /// </summary>
        /// <param name="currencyPair">The currency pair to trade in</param>
        /// <param name="orderId">The Id of the order to check status for</param>
        /// <returns></returns>
        public async Task<WebCallResult<VALRSimpleBuySellOrderStatus>> SimpleBuySellOrderStatusAsync(string currencyPair, string orderId, CancellationToken ct = default)
        {
            var result = await SendRequest<VALRSimpleBuySellOrderStatus>(GetUrl(FillPathParameter(SimpleBuySellOrderStatusEndpoint, currencyPair, orderId), ApiVersion1), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<VALRSimpleBuySellOrderStatus>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<VALRSimpleBuySellOrderStatus>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Create a new limit order. 
        /// </summary>
        /// <param name="side"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <param name="pair"></param>
        /// <param name="postOnly"></param>
        /// <param name="customerOrderId"></param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public WebCallResult<VALRIdResult> LimitOrder(TradeSide side, decimal quantity, decimal price, string pair, bool postOnly, string customerOrderId, CancellationToken ct = default)
            => LimitOrderAsync(side, quantity, price, pair, postOnly, customerOrderId, ct).Result;

        /// <summary>
        /// Create a new limit order. 
        /// </summary>
        /// <param name="side"></param>
        /// <param name="quantity"></param>
        /// <param name="price"></param>
        /// <param name="pair"></param>
        /// <param name="postOnly"></param>
        /// <param name="customerOrderId"></param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public async Task<WebCallResult<VALRIdResult>> LimitOrderAsync(TradeSide side, decimal quantity, decimal price, string pair, bool postOnly, string customerOrderId, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "side", side.ToString() },
                { "quantity", quantity },
                { "price", price },
                { "pair", pair },
                { "postOnly", postOnly },
                { "customerOrderId", customerOrderId }
            };

            //TODO: Keeps complaining about invalid signature even though authenticator signing test passes???
            var result = await SendRequest<VALRIdResult>(GetUrl(LimitOrderEndpoint, ApiVersion1), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<VALRIdResult>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<VALRIdResult>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Create a new market order. 
        /// </summary>
        /// <param name="side"></param>
        /// <param name="baseAmount"></param>
        /// <param name="pair"></param>
        /// <param name="customerOrderId"></param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public WebCallResult<VALRIdResult> MarketOrder(TradeSide side, decimal baseAmount, string pair, string customerOrderId, CancellationToken ct = default)
            => MarketOrderAsync(side, baseAmount, pair, customerOrderId, ct).Result;

        /// <summary>
        /// Create a new market order. 
        /// </summary>
        /// <param name="side">BUY or SELL</param>
        /// <param name="baseAmount">Quote amount for BUY (in ZAR). Base amount for SELL (in BTC, ETH or XRP). The base amount will be truncated to baseDecimalPlaces of the currency pair.</param>
        /// <param name="pair">Can be BTCZAR, ETHZAR or XRPZAR</param>
        /// <param name="customerOrderId">Customers own order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        public async Task<WebCallResult<VALRIdResult>> MarketOrderAsync(TradeSide side, decimal baseAmount, string pair, string customerOrderId, CancellationToken ct = default)
        {
            var parameters = new Dictionary<string, object>
            {
                { "side", side.ToString() },
                { "baseAmount", baseAmount },
                { "pair", pair },
                { "customerOrderId", customerOrderId }
            };

            //TODO: Keeps complaining about invalid signature even though authenticator signing test passes???
            var result = await SendRequest<VALRIdResult>(GetUrl(MarketOrderEndpoint, ApiVersion1), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<VALRIdResult>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<VALRIdResult>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Get the status of a Simple Buy/Sell order.
        /// </summary>
        /// <param name="currencyPair">The currency pair to trade in</param>
        /// <param name="orderId">The Id of the order to check status for</param>
        /// <returns></returns>
        public WebCallResult<VALROrderStatusResult> OrderStatusByOrderId(string currencyPair, string orderId, CancellationToken ct = default) => OrderStatusByOrderIdAsync(currencyPair, orderId, ct).Result;

        /// <summary>
        /// Get the status of a Simple Buy/Sell order.
        /// </summary>
        /// <param name="currencyPair">The currency pair to trade in</param>
        /// <param name="orderId">The Id of the order to check status for</param>
        /// <returns></returns>
        public async Task<WebCallResult<VALROrderStatusResult>> OrderStatusByOrderIdAsync(string currencyPair, string orderId, CancellationToken ct = default)
        {
            var result = await SendRequest<VALROrderStatusResult>(GetUrl(FillPathParameter(OrderStatusByOrderIdEndpoint, currencyPair, orderId), ApiVersion1), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<VALROrderStatusResult>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<VALROrderStatusResult>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Get the status of a Simple Buy/Sell order.
        /// </summary>
        /// <param name="currencyPair">The currency pair to trade in</param>
        /// <param name="customerOrderId">The customer order Id of the order to check status for</param>
        /// <returns></returns>
        public WebCallResult<VALROrderStatusResult> OrderStatusByCustomerOrderId(string currencyPair, string customerOrderId, CancellationToken ct = default) => OrderStatusByCustomerOrderIdAsync(currencyPair, customerOrderId, ct).Result;

        /// <summary>
        /// Get the status of a Simple Buy/Sell order.
        /// </summary>
        /// <param name="currencyPair">The currency pair to trade in</param>
        /// <param name="customerOrderId">The customer order Id of the order to check status for</param>
        /// <returns></returns>
        public async Task<WebCallResult<VALROrderStatusResult>> OrderStatusByCustomerOrderIdAsync(string currencyPair, string customerOrderId, CancellationToken ct = default)
        {
            var result = await SendRequest<VALROrderStatusResult>(GetUrl(FillPathParameter(OrderStatusByCustomerOrderIdEndpoint, currencyPair, customerOrderId), ApiVersion1), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<VALROrderStatusResult>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<VALROrderStatusResult>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
        }

        /// <summary>
        /// Get all open orders for your account.
        /// </summary>
        /// <returns></returns>
        public WebCallResult<IEnumerable<VALROpenOrder>> AllOpenOrders(CancellationToken ct = default) => AllOpenOrdersAsync(ct).Result;

        /// <summary>
        /// Get all open orders for your account.
        /// </summary>
        /// <returns></returns>
        public async Task<WebCallResult<IEnumerable<VALROpenOrder>>> AllOpenOrdersAsync(CancellationToken ct = default)
        {
            var result = await SendRequest<IEnumerable<VALROpenOrder>>(GetUrl(AllOpenOrdersEndpoint, ApiVersion1), HttpMethod.Get, ct, null, true).ConfigureAwait(false);
            if (!result)
                return WebCallResult<IEnumerable<VALROpenOrder>>.CreateErrorResult(result.ResponseStatusCode, result.ResponseHeaders, result.Error!);
            return new WebCallResult<IEnumerable<VALROpenOrder>>(result.ResponseStatusCode, result.ResponseHeaders, result.Data, null);
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
