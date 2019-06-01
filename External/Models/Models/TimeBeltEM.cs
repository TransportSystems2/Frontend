using System;
namespace TransportSystems.Frontend.External.Models.Models
{
    public struct TimeBeltEM
    {
        /// <summary>
        /// The offset for daylight-savings time.
        /// </summary>
        public TimeSpan OffSet { get; set; }

        /// <summary>
        /// The offest from UTC.
        /// </summary>
        public TimeSpan RawOffset { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}
