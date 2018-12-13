using System.Collections.Generic;
using TransportSystems.Frontend.External.Models.Geo;

namespace TransportSystems.Frontend.External.Models.Models.Routing
{
    public class WaypointsEM
    {
        public List<AddressEM> Points { get; set; }

        public string Comment { get; set; }
    }
}
