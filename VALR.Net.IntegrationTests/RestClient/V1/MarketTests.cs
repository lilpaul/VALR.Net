using NUnit.Framework;
using Microsoft.Extensions.Configuration;

namespace VALR.Net.IntegrationTests.RestClient.V1
{
    public class MarketTests
    {
        private VALRClient client;

        [SetUp]
        public void Setup()
        {
            var configBuilder = new ConfigurationBuilder();
            //add the project secrets as per the readme file
            //you may need to change this secrets id to get the tests to run on your machine
            configBuilder.AddUserSecrets("41b77175-1e97-46bf-88aa-80d90eedb052");
            var root = configBuilder.Build();
            var viewOnly = root.GetSection("Withdrawal");
            var apikey = viewOnly.GetSection("ApiKey").Value;
            var apiSecret = viewOnly.GetSection("ApiSecret").Value;

            client = new VALRClient();
            client.SetApiCredentials(apikey, apiSecret);
        }

        [Test]
        public void GetOrderBook()
        {
            var result = client.GetOrderBook("BTCZAR");
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void GetDetailedOrderBook()
        {
            var result = client.GetDetailedOrderBook("BTCZAR");
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void GetMarketTradeHistory()
        {
            var result = client.GetMarketTradeHistory("BTCZAR");
            Assert.IsTrue(result.Success);
        }
    }
}
