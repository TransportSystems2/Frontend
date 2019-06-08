namespace TransportSystems.Frontend.App.Models.Geo
{
    public class AddressM
    {
        public string Country { get; set; }

        public string Province { get; set; }

        public string Area { get; set; }

        public string Locality { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string Request { get; set; }

        public string FormattedText { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double AdjustedLatitude { get; set; }

        public double AdjustedLongitude { get; set; }
    }
}