using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRWithdrawalInfo
    {
        public string Currency { get; set; } //"BTC"
        public decimal MinimumWithdrawAmount { get; set; } //"0.0002"
        public bool IsActive { get; set; } //true
        public decimal WithdrawCost { get; set; } //"0.0004"
        public bool SupportsPaymentReference { get; set; } //false
    }
}
