using System.Threading.Tasks;
using Moq;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Cargo;
using TransportSystems.Frontend.Core.Domain.Interfaces.Cargo;
using TransportSystems.Frontend.Core.Infrastructure.Business.Cargo;
using TransportSystems.Frontend.Core.Services.Interfaces.Cargo;
using Xunit;

namespace TransportSystems.Frontend.Core.UnitTests.Infrastructure.Business
{
    public class CargoServiceTestSuite
    {
        public CargoServiceTestSuite()
        {
            CargoRepositoryMock = new Mock<ICargoRepository>();
            CargoService = new CargoService(CargoRepositoryMock.Object);
        }

        public ICargoService CargoService { get; }

        public Mock<ICargoRepository> CargoRepositoryMock { get; }
    }

    public class CargoServiceTests
    {
        public CargoServiceTests()
        {
            Suite = new CargoServiceTestSuite();
        }

        protected CargoServiceTestSuite Suite { get; }

        [Fact]
        public async Task GetAvailableParams()
        {
            var priority = RequestPriority.UserInitiated;
            var domainParams = new CargoCatalogItemsDM();

            Suite.CargoRepositoryMock
                .Setup(m => m.GetAvailableParams(priority))
                .ReturnsAsync(domainParams);

            var availableParams = await Suite.CargoService.GetAvailableParams(priority);

            Suite.CargoRepositoryMock
                .Verify(m => m.GetAvailableParams(priority), Times.Once);

            Assert.Equal(domainParams, availableParams);
        }
    }
}