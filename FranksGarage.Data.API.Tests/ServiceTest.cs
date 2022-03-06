using FranksGarage.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FranksGarage.Data.API.Tests
{
    public class ServiceTest
    {
        [Fact]
        public async Task Get_AllVehicles()
        {
            var application = new TestApplication();
            var client = application.CreateClient();

            var response = await client.GetStringAsync("/Vehicles");
            List<VehiclesModel>? deserilized = new List<VehiclesModel>();
            deserilized = response != null ? JsonConvert.DeserializeObject<List<VehiclesModel>>(response.Replace("\n", "").Replace("\\", "")) : null;

            Assert.True(deserilized?.Count > 0);
        }

        [Fact]
        public async Task GetById_AllVehicles()
        {
            var application = new TestApplication();
            var client = application.CreateClient();

            var response = await client.GetStringAsync("/Vehicles/1");
            VehicleProxyModel? deserilized = new VehicleProxyModel();
            deserilized = response != null ? JsonConvert.DeserializeObject<VehicleProxyModel>(response.Replace("\n", "").Replace("\\", "")) : null;

            Assert.Equal("Volkswagen", deserilized?.VehicleMake);
        }
    }
}