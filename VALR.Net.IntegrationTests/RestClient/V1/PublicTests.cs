using NUnit.Framework;

namespace VALR.Net.IntegrationTests.RestClient.V1
{
    public class PublicTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetCurrencyPairsList()
        {
            var client = new VALRClient();
            var result = client.GetCurrencyPairs();
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void GetAllOrderTypes()
        {
            var client = new VALRClient();
            var result = client.GetPairOrderTypes();
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void GetOrderTypes()
        {
            var client = new VALRClient();
            var result = client.GetPairOrderTypes("BTCZAR");
            Assert.IsTrue(result.Success);
        }


        [Test]
        public void GetMarketSummaries()
        {
            var client = new VALRClient();
            var result = client.GetMarketSummary();
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void GetMarketSummary()
        {
            var client = new VALRClient();
            var result = client.GetMarketSummary("BTCZAR");
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void GetCurrencyList()
        {
            var client = new VALRClient();
            var result = client.GetCurrencies();
            Assert.IsTrue(result.Success);
        }
    }
}
