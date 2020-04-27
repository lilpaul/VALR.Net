using NUnit.Framework;

namespace VALR.Net.IntegrationTests.RestClient.V1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
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