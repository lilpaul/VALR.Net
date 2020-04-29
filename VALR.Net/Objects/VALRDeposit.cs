using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRDeposit
    {
        public string CurrencyCode { get; set; } //"BTC"
        public string ReceiveAddress { get; set; } //"2MvLmR6cd4YVDFAU8BTujKkzrV1dwFaNHup"
        public string TransactionHash { get; set; } //"fb588e3be006058c5853880421ef7241388270e2b506ce7ca553f8e5b797f628"
        public decimal Amount { get; set; } //"0.01"
        public DateTime CreatedAt { get; set; } //"2019-03-01T14:36:53Z"
        public int Confirmations { get; set; } //2
        public bool Confirmed { get; set; } //true
        public DateTime ConfirmedAt { get; set; } //"2019-03-01T14:48:47.340347Z"
    }
}
