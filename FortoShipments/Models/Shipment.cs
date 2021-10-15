using FortoShipments.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FortoShipments.Models
{
    public class ShipmentList
    {
        [JsonProperty("shipments")]
        public List<Shipment> Shipments { get; set; }
    }
    public partial class Shipment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cargo")]
        public List<Cargo> Cargo { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("services")]
        public List<Service> Services { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public partial class Cargo
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("volume")]
        public string Volume { get; set; }
    }

    public partial class Service
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        public long? Value { get; set; }
    }
}
