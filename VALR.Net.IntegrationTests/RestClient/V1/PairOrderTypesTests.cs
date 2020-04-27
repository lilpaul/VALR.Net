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
    }
}
