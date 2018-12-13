using System.Collections.Generic;
using TransportSystems.Frontend.Core.Domain.Core.Catalogs;

namespace TransportSystems.Frontend.Core.Domain.Core.Cargo
{
    public class CargoCatalogItemsDM
    {
        public CargoCatalogItemsDM()
        {
            Brands = new List<CatalogItemDM>();
            Weights = new List<CatalogItemDM>();
            Kinds = new List<CatalogItemDM>();
        }

        public List<CatalogItemDM> Brands { get; set; }

        public List<CatalogItemDM> Weights { get; set; }

        public List<CatalogItemDM> Kinds { get; set; }
    }
}