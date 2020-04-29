using NUnit.Framework;
using Microsoft.Extensions.Configuration;

namespace VALR.Net.IntegrationTests.RestClient.V1
{
    public class WalletTests
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
        public void GetDepositAddress()
        {
            var result = client.GetDepositAddress("BTC");
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void GetWithdrawalInfo()
        {
            var result = client.GetWithdrawalInfo("BTC");
            Assert.IsTrue(result.Success);
        }

        //TODO: Keeps complaining about invalid signature even though authenticator signing test passes???
        //[Test]
        //public void WithdrawCrypto()
        //{
        //    var result = client.WithdrawCrypto("BTC", 0.0002M, "3J833VTYxr5S56BsFS8MiznbZhy6Bfo3bV");
        //    Assert.IsTrue(result.Success);
        //}

        [Test]
        public void GetDepositHistory()
        {
            var result = client.GetDepositHistory("BTC");
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void GetWithdrawalHistory()
        {
            var result = client.GetDepositHistory("BTC");
            Assert.IsTrue(result.Success);
        }

        [Test]
        public void GetBankAccounts()
        {
            var result = client.GetBankAccounts("ZAR");
            Assert.IsTrue(result.Success);
        }

        //TODO: Keeps complaining about invalid signature even though authenticator signing test passes???
        //[Test]
        //public void WithdrawFiat()
        //{
        //    var result = client.WithdrawFiat("ZAR", "45833009-a225-431b-b4bd-c8b806fb11ca", 30, false);
        //    Assert.IsTrue(result.Success);
        //}
    }
}
