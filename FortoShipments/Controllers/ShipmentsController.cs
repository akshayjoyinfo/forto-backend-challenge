using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FortoShipments.Models;
using FortoShipments.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FortoShipments.Controllers
{
    [Route("api/shipments")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        public ShipmentController(IMemoryCache cache)
        {
            _cache = cache;
        }
        [HttpGet]
        public IActionResult GetAllShipments([FromQuery(Name ="page")] int page=1, [FromQuery(Name = "limit")]  int limit=10,
            [FromQuery(Name = "order")] string order = "id", [FromQuery(Name ="dir")] string orderBy="asc")
        {
            var shipmentData = (ShipmentList)_cache.Get("SHIPMENTS");

            Func<Shipment, object> orderFunc = null;
            IEnumerable<Shipment> result = null;

            if (order == "id")
                orderFunc = ship => ship.Id;
            else
                orderFunc = ship => ship.Name;

            if(orderBy=="asc")
                result = shipmentData.Shipments
                    .OrderBy(orderFunc)
                    .Skip(limit * (page-1)).Take(limit);
            else
                result = shipmentData.Shipments
                    .OrderByDescending(orderFunc)
                    .Skip(limit * (page - 1)).Take(limit);

            return Ok(result);
        }

        // GET api/<ShipmentsController>/5
        [HttpGet("{id}")]
        public IActionResult GetShipment(string id)
        {
            var shipmentData = (ShipmentList)_cache.Get("SHIPMENTS");
            var shipment = shipmentData.Shipments.FirstOrDefault(s => s.Id == id);
            if (shipment == null)
            {
                return NotFound();
            }

            return Ok(shipment);
        }




        // POST api/<ShipmentsController>
        [HttpPut("{id}")]
        public IActionResult UpdateShipments(string id, [FromBody] Shipment shipmentRequest)
        {
            var shipmentData = (ShipmentList)_cache.Get("SHIPMENTS");
            if(shipmentRequest == null || string.IsNullOrEmpty(shipmentRequest.Name))
            {
                return BadRequest();
            }
            var shipment = shipmentData.Shipments.FirstOrDefault(s => s.Id == id);
            if (shipment == null)
            {
                return NotFound();
            }
            // update those details
            shipment.Name = shipmentRequest.Name;
            _cache.Set("SHIPMENTS", shipmentData);

            return Ok(shipment);

        }
    }
}
