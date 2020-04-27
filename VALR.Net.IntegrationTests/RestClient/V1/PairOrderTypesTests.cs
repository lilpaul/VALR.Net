using NUnit.Framework;

namespace VALR.Net.IntegrationTests.RestClient.V1
{
    public class PairOrderTypesTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetCurrencyList()
        {
            var client = new VALRClient();
            var result = client.GetPairOrderTypes();
            Assert.IsTrue(result.Success);
        }
    }
}
