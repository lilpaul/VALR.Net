using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALROpenOrder
    {
        public string OrderId { get; set; } //"da99bd40-41a2-42dd-8601-bc99edc31df2"
        public string Side { get; set; } //"sell"
        public string Price { get; set; } //"100000"
        public string CurrencyPair { get; set; } //"BTCZAR"
        public string CreatedAt { get; set; } //"2019-05-09T20:20:30.573Z"
        public string RemainingQuantity { get; set; } //"0.1"
        public string OriginalQuantity { get; set; } //"0.1"
        public string FilledPercentage { get; set; } //"0.00"
        public string CustomerOrderId { get; set; } //"1"
    }
}
