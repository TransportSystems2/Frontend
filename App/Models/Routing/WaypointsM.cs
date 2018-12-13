using System;
using System.Collections.Generic;
using TransportSystems.Frontend.App.Models.Geo;

namespace TransportSystems.Frontend.App.Models.Routing
{
    public class WaypointsM
    {
        public List<AddressM> Points { get; set; }

        public string Comment { get; set; }
    }
}
