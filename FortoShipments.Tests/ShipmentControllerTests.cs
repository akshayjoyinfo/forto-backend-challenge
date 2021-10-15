using FortoShipments.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FortoShipments.Tests
{
    public class ShipmentControllerTests : IClassFixture<ShipmentApiFactory<FortoShipments.Startup>>
    {
        private readonly HttpClient _client;
        private readonly ShipmentApiFactory<FortoShipments.Startup> _factory;

        public ShipmentControllerTests(ShipmentApiFactory<FortoShipments.Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task GetAllShipmentShouldRetrieveShipments()
        {
            var getAllShipmentResponse = await _client.GetAsync("/api/shipments");

            var stringResponse = await getAllShipmentResponse.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<Shipment>>(stringResponse);


            // Assert
            Assert.Equal(HttpStatusCode.OK, getAllShipmentResponse.StatusCode);

            Assert.Equal(10, result.Count);
        }

        [Fact]
        public async Task GetShipmentDetailsShouldRetrieveSingleShipment()
        {
            var getAllShipmentResponse = await _client.GetAsync("/api/shipments/S1000");

            var stringResponse = await getAllShipmentResponse.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Shipment>(stringResponse);


            // Assert
            Assert.Equal(HttpStatusCode.OK, getAllShipmentResponse.StatusCode);

            
            Assert.Equal("S1000", result.Id);
            Assert.Equal("ACTIVE", result.Status);
        }

        [Fact]
        public async Task UpdtaeShipmentDetailsShouldUpdateOnlyName()
        {

            var content = new StringContent("{ \"name\" : \"Maersk Shipment Container\" }", Encoding.UTF8, "application/json");

            var updateShipment = await _client.PutAsync("/api/shipments/S1000", content);

            var stringResponse = await updateShipment.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Shipment>(stringResponse);


            // Assert
            Assert.Equal(HttpStatusCode.OK, updateShipment.StatusCode);


            Assert.Equal("S1000", result.Id);
            Assert.Equal("Maersk Shipment Container", result.Name);
            Assert.Equal("ACTIVE", result.Status);
        }
    }
}
