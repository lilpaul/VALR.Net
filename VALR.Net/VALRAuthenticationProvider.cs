using CryptoExchange.Net.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace VALR.Net
{
    public class VALRAuthenticationProvider : AuthenticationProvider
    {
        public VALRAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        {
            if (credentials.Secret == null)
                throw new ArgumentException("ApiKey/Secret needed");

            //locker = new object();
            //encryptor = new HMACSHA384(Encoding.UTF8.GetBytes(credentials.Secret.GetString()));
        }
    }
}
