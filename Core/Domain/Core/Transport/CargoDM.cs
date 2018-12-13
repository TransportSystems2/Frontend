using System;

namespace TransportSystems.Frontend.Core.Domain.Core.Transport
{
    public class CargoDM
    {
        public int WeightCatalogItemId { get; set; }

        public int KindCatalogItemId { get; set; }

        public int BrandCatalogItemId { get; set; }

        public string RegistrationNumber { get; set; }

        public string Comment { get; set; }
    }
}
