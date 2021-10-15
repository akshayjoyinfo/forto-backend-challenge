using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FortoShipments.Enums
{
    public enum Mode 
    { 
        air, 
        sea 
    };

    public enum ServiceType 
    { 
        customs, 
        insurance 
    };

    public enum Status 
    { 
        ACTIVE, 
        COMPLETED, 
        NEW 
    };

    public enum ShipmentType 
    { 
        FCL, 
        LCL 
    };

}
