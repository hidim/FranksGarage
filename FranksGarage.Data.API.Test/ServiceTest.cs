using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace FranksGarage.Data.API.Test
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public async void GetServiceTest()
        {
            var client = new TestClientProvider().Client;

            var okREsult = await client.GetAsync("Vehicles");

            okREsult.EnsureSuccessStatusCode();

            Assert.Equals(HttpStatusCode.OK, okREsult.StatusCode);
        }
    }
}
