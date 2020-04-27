using NUnit.Framework;

namespace VALR.Net.IntegrationTests.RestClient.V1
{
    class MarketSummaryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetMarketSummaries()
        {
            var client = new VALRClient();
            var result = client.GetMarketSummary();
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void GetOrderTypes()
        {
            var client = new VALRClient();
            var result = client.GetMarketSummary("BTCZAR");
            Assert.IsTrue(result.Success);
        }
    }
}
