using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;

namespace VALR.Net.IntegrationTests
{
    public class AuthenticatorTests
    {
        private VALRAuthenticationProvider provider;
        
        [SetUp]
        public void Setup()
        {
            provider = new VALRAuthenticationProvider(
                new CryptoExchange.Net.Authentication.ApiCredentials(
                    "MOCK_API_KEY",
                    "4961b74efac86b25cce8fbe4c9811c4c7a787b7a5996660afcc2e287ad864363"
                ));
        }

        [Test]
        public void TestGetSigning()
        {
            //timestamp 	1558014486185
            //verb 	GET
            //path 	/v1/account/balances
            string expected = "9d52c181ed69460b49307b7891f04658e938b21181173844b5018b2fe783a6d4c62b8e67a03de4d099e7437ebfabe12c56233b73c6a0cc0f7ae87e05f6289928";
            string uri = "https://api.valr.com/v1/account/balances";
            HttpMethod method = HttpMethod.Get;
            string timestamp = "1558014486185";
            Dictionary<string, object> parameters = new Dictionary<string, object>(); 

            var result = provider.AddAuthenticationToHeaders(uri, method, parameters, true, timestamp);
            Assert.AreEqual(expected, result["X-VALR-SIGNATURE"].ToString());
        }

        [Test]
        public void TestPostSigning()
        {
            //timestamp 	1558017528946
            //verb 	POST
            //path 	/v1/orders/market
            //body {"customerOrderId":"ORDER-000001","pair":"BTCZAR","side":"BUY","quoteAmount":"80000"}
            string expected = "be97d4cd9077a9eea7c4e199ddcfd87408cb638f2ec2f7f74dd44aef70a49fdc49960fd5de9b8b2845dc4a38b4fc7e56ef08f042a3c78a3af9aed23ca80822e8";
            string uri = "https://api.valr.com/v1/orders/market";
            HttpMethod method = HttpMethod.Post;
            string timestamp = "1558017528946";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("customerOrderId", "ORDER-000001");
            parameters.Add("pair", "BTCZAR");
            parameters.Add("side", "BUY");
            parameters.Add("quoteAmount", "80000");

            var result = provider.AddAuthenticationToHeaders(uri, method, parameters, true, timestamp);
            Assert.AreEqual(expected, result["X-VALR-SIGNATURE"].ToString());
        }
    }
}
