using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net.Objects
{
    public class VALRCodeMessageResult
    {
        public int Code { get; set; } //-12005,
        public string Message { get; set; } //"Selected order type is not allowed for the currency pair."
    }
}
