using System;
namespace TransportSystems.Frontend.External.Models.Models.Transport
{
    public class CargoEM
    {
        public int WeightCatalogItemId { get; set; }

        public int KindCatalogItemId { get; set; }

        public int BrandCatalogItemId { get; set; }

        public string RegistrationNumber { get; set; }

        public string Comment { get; set; }
    }
}
