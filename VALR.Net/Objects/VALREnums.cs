using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace VALR.Net.Objects
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderType
    {
        [EnumMember(Value = "LIMIT_POST_ONLY")]
        PostOnlyLimit,
        [EnumMember(Value = "LIMIT")]
        Limit,
        [EnumMember(Value = "MARKET")]
        Market,
        [EnumMember(Value = "SIMPLE")]
        Simple
    }
}
