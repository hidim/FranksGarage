using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FranksGarage.Data.API.Test
{
    public class TestClientProvider
    {
        public HttpClient Client { get; set; }

        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<StartupBase>());

            Client = server.CreateClient();
        }
    }
}
