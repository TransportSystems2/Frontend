using System.Collections.Generic;
using TransportSystems.Frontend.External.Models.Catalogs;

namespace TransportSystems.Frontend.External.Models.Cargo
{
    public class CargoCatalogItemsEM
    {
        public CargoCatalogItemsEM()
        {
            Brands = new List<CatalogItemEM>();
            Weights = new List<CatalogItemEM>();
            Kinds = new List<CatalogItemEM>();
        }

        public List<CatalogItemEM> Brands { get; set; }

        public List<CatalogItemEM> Weights { get; set; }

        public List<CatalogItemEM> Kinds { get; set; }
    }
}