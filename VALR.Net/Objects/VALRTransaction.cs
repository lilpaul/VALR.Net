using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRTransaction
    {
        public VALRTransactionType TransactionType { get; set; }
        public string DebitCurrency { get; set; }
        public decimal DebitValue { get; set; }
        public string CreditCurrency { get; set; }
        public decimal CreditValue { get; set; }
        public string FeeCurrency { get; set; }
        public decimal FeeValue { get; set; }
        public DateTime EventAt { get; set; }
        public dynamic AdditionalInfo { get; set; }
    }
}
