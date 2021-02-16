using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace BankingRESTfulService.Test
{
    [TestClass]
    public class APITest
    {
        [TestMethod]
        public async Task TestApiVersion()
        {
            var factory = new WebApplicationFactory<Startup>();
            var Client = factory.CreateClient();
            var result = await Client.GetAsync("/bank/api/version");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            var content = result.Content;
            var data = await content.ReadAsStringAsync();
            Assert.AreEqual($"{DateTime.UtcNow.ToString("yyyy.MM.dd", CultureInfo.InvariantCulture)}.1.0", data);
        }

        [TestMethod]
        public async Task TestApiVersion_Second()
        {
            var factory = new WebApplicationFactory<Startup>();
            var Client = factory.CreateClient();
            var result = await Client.GetAsync("/bank/api-version");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            var content = result.Content;
            var data = await content.ReadAsStringAsync();
            Assert.AreEqual($"{DateTime.UtcNow.ToString("yyyy.MM.dd", CultureInfo.InvariantCulture)}.1.0", data);
        }

        [TestMethod]
        public async Task TestPasswordStrongIsFalse()
        {
            var factory = new WebApplicationFactory<Startup>();
            var Client = factory.CreateClient();
            var result = await Client.GetAsync($"/bank/api/password/strong/123");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            var content = result.Content;
            var data = await content.ReadAsStringAsync();
            Assert.AreEqual("false", data);
        }

        [TestMethod]
        public async Task TestPasswordStrongIsTrue()
        {
            var factory = new WebApplicationFactory<Startup>();
            var Client = factory.CreateClient();
            var result = await Client.GetAsync($"/bank/api/password/strong/ALhj89*1");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            var content = result.Content;
            var data = await content.ReadAsStringAsync();
            Assert.AreEqual("true", data);
        }

        [TestMethod]
        public async Task CalculateMD5()
        {
            var factory = new WebApplicationFactory<Startup>();
            var Client = factory.CreateClient();
            var result = await Client.GetAsync($"/bank/api/calc/MD5/test-string-1");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            var content = result.Content;
            var data = await content.ReadAsStringAsync();
            Assert.AreEqual("7FE8C14D5E3D1CFB648F77F05766A013", data);
        }

        [TestMethod]
        public async Task CalculateMD5_SecondURL()
        {
            var factory = new WebApplicationFactory<Startup>();
            var Client = factory.CreateClient();
            var result = await Client.GetAsync($"/bank/api/calc/1/MD5");
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
            var content = result.Content;
            var data = await content.ReadAsStringAsync();
            Assert.AreEqual("C4CA4238A0B923820DCC509A6F75849B", data);
        }
    }
}
