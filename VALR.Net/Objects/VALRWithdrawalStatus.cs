using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRWithdrawalStatus
    {
        public string Currency { get; set; } //"BTC"
        public string Address { get; set; } //"mkHS9ne12qx9pS9VojpwU5xtRd4T7X7ZUt"
        public decimal Amount { get; set; } //"0.001"
        public decimal FeeAmount { get; set; } //"0.0002"
        public string TtransactionHash { get; set; } //"1558363779645"
        public int Confirmations { get; set; } //2
        public DateTime LastConfirmationAt { get; set; } //"2019-05-20T14:49:59.659675"
        public string UniqueId { get; set; } //"b8e2e6c0-5215-4f6b-80b4-a664b2b6ef94"
        public DateTime CreatedAt { get; set; } //"2019-05-20T14:49:39.609Z"
        public bool Verified { get; set; } //true
        public string Status { get; set; } //"Processing"
    }
}
