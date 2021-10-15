using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;

namespace FortoShipments.Tests
{
    public class ShipmentApiFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {

    }
}
