using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRBankAccount
    {
        public string Id { get; set; } //"c05d17fc-3019-4549-abe6-42037c7ca7f0"
        public string Bank { get; set; } //"FNB/RMB"
        public string AccountHolder { get; set; } //"Badi Sudhakaran"
        public string AccountNumber { get; set; } //"*****5654"
        public string BranchCode { get; set; } //"254005"
        public string AccountType { get; set; } //"Savings"
        public DateTime CreatedAt { get; set; } //"2019-04-20T10:01:31.668814Z"
    }
}
