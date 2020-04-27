using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VALR.Net.Objects;

namespace VALR.Net.Interfaces
{
    public interface IVALRClient : IRestClient
    {
        /// <summary>
        /// Gets a list of supported currencies
        /// </summary>
        /// <param name="ct">Cancellation token</param><returns></returns>
        WebCallResult<IEnumerable<VALRCurrency>> GetCurrencies(CancellationToken ct = default);

        /// <summary>
        /// Gets a list of supported currencies
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<WebCallResult<IEnumerable<VALRCurrency>>> GetCurrenciesAsync(CancellationToken ct = default);
    }
}
