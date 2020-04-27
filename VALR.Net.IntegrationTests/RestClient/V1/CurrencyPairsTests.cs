using NUnit.Framework;

namespace VALR.Net.IntegrationTests.RestClient.V1
{
    public class CurrencyPairsTests
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
    }
}
