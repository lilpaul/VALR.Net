using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace VALR.Net
{
    public class VALRAuthenticationProvider : AuthenticationProvider
    {
        private readonly HMACSHA512 encryptor;
        private readonly object locker;
        
        public VALRAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        {
            if (credentials.Secret == null)
                throw new ArgumentException("ApiKey/Secret needed");

            locker = new object();
            encryptor = new HMACSHA512(Encoding.UTF8.GetBytes(credentials.Secret.GetString()));
        }

        public override Dictionary<string, string> AddAuthenticationToHeaders(string uri, HttpMethod method, Dictionary<string, object> parameters, bool signed)
        {
            if (Credentials.Key == null)
                throw new ArgumentException("ApiKey/Secret needed");

            var result = new Dictionary<string, string>();
            if (!signed)
                return result;

            if (uri.Contains("v1"))
            {
                var path = new Uri(uri).PathAndQuery;
                var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
                //body is optional in signature - consider removing if it causes issues when not empty
                var body = "";
                if (parameters.Count > 0)
                {
                    body = JsonConvert.SerializeObject(parameters);
                }
                var payload = $"{timestamp}{method.ToString().ToUpper()}{path}{body}";
                var signedData = Sign(payload);

                result.Add("X-VALR-API-KEY", Credentials.Key.GetString());
                result.Add("X-VALR-TIMESTAMP", timestamp.ToString());
                result.Add("X-VALR-SIGNATURE", signedData.ToLower());
            }
            else if (uri.Contains("v2"))
            {
                throw new ArgumentException("Only api v1 supported");
            }

            return result;
        }

        public override string Sign(string toSign)
        {
            lock (locker)
                return ByteToString(encryptor.ComputeHash(Encoding.UTF8.GetBytes(toSign)));
        }
    }
}
