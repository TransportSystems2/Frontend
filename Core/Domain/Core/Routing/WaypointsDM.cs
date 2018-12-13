using System.Collections.Generic;
using TransportSystems.Frontend.Core.Domain.Core.Geo;

namespace TransportSystems.Frontend.Core.Domain.Core.Cargo
{
    public class WaypointsDM
    {
        public WaypointsDM()
        {
            Points = new List<AddressDM>();
        }

        public List<AddressDM> Points { get; set; }

        public string Comment { get; set; }
    }
}
