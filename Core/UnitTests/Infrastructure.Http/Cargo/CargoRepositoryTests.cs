using System.Threading.Tasks;
using Moq;
using TransporSystems.Frontend.Utils.Mapping;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Cargo;
using TransportSystems.Frontend.Core.Domain.Interfaces.Cargo;
using TransportSystems.Frontend.Core.Infrastructure.Http.Cargo;
using TransportSystems.Frontend.External.Interfaces;
using TransportSystems.Frontend.External.Interfaces.Cargo;
using TransportSystems.Frontend.External.Models.Cargo;
using Xunit;

namespace TransportSystems.Frontend.Core.UnitTests.Infrastructure.Http.Cargo
{
    public class CargoRepositoryTestSuite
    {
        public CargoRepositoryTestSuite()
        {
            APIManagerMock = new Mock<IAPIManager>();
            MappingServiceMock = new Mock<IMappingService>();
            CargoRepository = new CargoRepository(APIManagerMock.Object, MappingServiceMock.Object);

            CargoAPIMock = new Mock<ICargoAPI>();

            APIManagerMock
                .Setup(m => m.Get<ICargoAPI>((External.Models.Models.RequestPriority)RequestPriority.UserInitiated))
                .Returns(CargoAPIMock.Object);
        }

        public Mock<IAPIManager> APIManagerMock { get; }

        public Mock<IMappingService> MappingServiceMock { get; }

        public ICargoRepository CargoRepository { get; }

        public Mock<ICargoAPI> CargoAPIMock { get; }
    }

    public class CargoRepositoryTests
    {
        public CargoRepositoryTests()
        {
            Suite = new CargoRepositoryTestSuite();
        }

        protected CargoRepositoryTestSuite Suite { get; }

        [Fact]
        public async Task GetAvailableParams()
        {
            var priority = RequestPriority.UserInitiated;
            var externalCatalogItems = new CargoCatalogItemsEM();
            var domainCatalogItems = new CargoCatalogItemsDM();

            Suite.CargoAPIMock
                .Setup(m => m.GetAvailableParams())
                .ReturnsAsync(externalCatalogItems);

            Suite.MappingServiceMock
                 .Setup(m => m.Map<CargoCatalogItemsDM>(externalCatalogItems))
                 .Returns(domainCatalogItems);

            var items = await Suite.CargoRepository.GetAvailableParams(priority);

            Suite.CargoAPIMock
                .Verify(m => m.GetAvailableParams(), Times.Once);

            Suite.MappingServiceMock
                .Verify(m => m.Map<CargoCatalogItemsDM>(externalCatalogItems), Times.Once);
                
            Assert.Equal(domainCatalogItems, items);
        }
    }
}
