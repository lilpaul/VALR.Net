using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRWithdrawal
    {
        public string Currency { get; set; } //"BTC"
        public string Address { get; set; } //"invalidAddress123"
        public decimal Amount { get; set; } //"0.0001"
        public decimal FeeAmount { get; set; } //"0.0002"
        public int Confirmations { get; set; } //0
        public string UniqueId { get; set; } //"2ab9dfce-7818-4812-9b33-fee7bd7c7c5a"
        public DateTime CreatedAt { get; set; } //"2019-04-20T14:30:26.950Z"
        public bool Verified { get; set; } //true
        public string Status { get; set; } //"Failed"
    }
}
