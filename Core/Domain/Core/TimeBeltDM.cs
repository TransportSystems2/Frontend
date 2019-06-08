using System;

namespace TransportSystems.Frontend.Core.Domain.Core
{
    public struct TimeBeltDM
    {
        public TimeSpan OffSet { get; set; }

        public TimeSpan RawOffset { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}
