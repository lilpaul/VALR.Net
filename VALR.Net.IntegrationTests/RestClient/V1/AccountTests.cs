﻿using NUnit.Framework;
using VALR.Net.Objects;
using CryptoExchange.Net.Authentication;
using Microsoft.Extensions.Configuration;

namespace VALR.Net.IntegrationTests.RestClient.V1
{
    public class AccountTests
    {
        private VALRClient client;
        private VALRClientOptions options;

        [SetUp]
        public void Setup()
        {
            var configBuilder = new ConfigurationBuilder();
            //add the project secrets as per the readme file
            //you may need to change this secrets id to get the tests to run on your machine
            configBuilder.AddUserSecrets("41b77175-1e97-46bf-88aa-80d90eedb052");
            var root = configBuilder.Build();
            var viewOnly = root.GetSection("ViewOnly");
            var apikey = viewOnly.GetSection("ApiKey").Value;
            var apiSecret = viewOnly.GetSection("ApiSecret").Value;

            options = new VALRClientOptions();
            options.ApiCredentials = new ApiCredentials(apikey, apiSecret);
            client = new VALRClient(options);
        }

        [Test]
        public void GetBalances()
        {
            var result = client.GetBalances();
            Assert.IsTrue(result.Success);
        }
    }
}