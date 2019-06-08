using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Domain.Interfaces.Address;
using TransportSystems.Frontend.Core.Infrastructure.Business.Address;
using TransportSystems.Frontend.Core.Services.Interfaces.Address;
using Xunit;

namespace TransportSystems.Frontend.Core.UnitTests.Infrastructure.Business
{
    public class AddressServiceTests
    {
        public AddressServiceTests()
        {
            Suite = new AddressTestSuite();
        }

        public AddressTestSuite Suite { get; }

        [Fact]
        public async Task GetAddress()
        {
            var request = "Москв";
            var priority = RequestPriority.UserInitiated;

            var addresses = new List<AddressDM> { new AddressDM() };

            Suite.AddressRepositoryMock
                .Setup(m => m.GetAddresses(request, priority))
                .ReturnsAsync(addresses);

            var results = await Suite.AddressService.GetAddresses(request, priority);

            Suite.AddressRepositoryMock
                .Verify(m => m.GetAddresses(request, priority), Times.Once);

            Assert.Equal(addresses, results);
        }

        [Fact]
        public async Task GetAddressByCoordinate()
        {
            var latitude = .0f;
            var longitude = .0f;
            var priority = RequestPriority.UserInitiated;

            var addresses = new List<AddressDM> { new AddressDM() };

            Suite.AddressRepositoryMock
                .Setup(m => m.GetAddressesByCoordinate(latitude, longitude, priority))
                .ReturnsAsync(addresses);

            var results = await Suite.AddressService.GetAddressesByCoordinate(latitude, longitude, priority);

            Suite.AddressRepositoryMock
                .Verify(m => m.GetAddressesByCoordinate(latitude, longitude, priority), Times.Once);

            Assert.Equal(addresses, results);
        }

        public class AddressTestSuite
        {
            public AddressTestSuite()
            {
                AddressRepositoryMock = new Mock<IAddressRepository>();
                AddressService = new AddressService(AddressRepositoryMock.Object);
            }

            public IAddressService AddressService { get; }

            public Mock<IAddressRepository> AddressRepositoryMock { get; }
        }
    }
}