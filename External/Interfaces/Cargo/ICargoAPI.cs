﻿using System.Threading.Tasks;
using Refit;
using TransportSystems.Frontend.External.Models.Cargo;

namespace TransportSystems.Frontend.External.Interfaces.Cargo
{
    public interface ICargoAPI
    {
        [Headers("Authorization: Bearer")]
        [Get("/api/cargos/catalog_items")]
        Task<CargoCatalogItemsEM> GetAvailableParams();
    }
}
