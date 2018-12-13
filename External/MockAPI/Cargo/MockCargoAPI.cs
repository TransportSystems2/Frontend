using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportSystems.Frontend.External.Interfaces.Cargo;
using TransportSystems.Frontend.External.Models.Cargo;
using TransportSystems.Frontend.External.Models.Catalogs;

namespace TransportSystems.Frontend.External.MockAPI.Cargo
{
    public class MockCargoAPI : ICargoAPI
    {
        public async Task<CargoCatalogItemsEM> GetAvailableParams()
        {
            await Task.Delay(1000);

            var result = new CargoCatalogItemsEM
            {
                Brands = new List<CatalogItemEM>
                {
                    new CatalogItemEM {Name = "Toyota", Value = 1},
                    new CatalogItemEM {Name = "Nissan", Value = 2},
                    new CatalogItemEM {Name = "BMW", Value = 3},
                },

                Weights = new List<CatalogItemEM>
                {
                    new CatalogItemEM {Name = "1 т", Value = 1000 },
                    new CatalogItemEM {Name = "2 т", Value = 2000 },
                    new CatalogItemEM {Name = "3 т", Value = 3000 }
                },

                Kinds = new List<CatalogItemEM>
                {
                    new CatalogItemEM { Name = "Мотоцикл", Value = 1},
                    new CatalogItemEM { Name = "Автомобиль", Value = 2},
                    new CatalogItemEM { Name = "Лодка", Value = 3}
                }
            };

            return result;
        }
    }
}
