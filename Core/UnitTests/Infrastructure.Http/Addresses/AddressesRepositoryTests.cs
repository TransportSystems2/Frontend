using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using TransporSystems.Frontend.Utils.Mapping;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Domain.Interfaces.Address;
using TransportSystems.Frontend.Core.Infrastructure.Http.Addresses;
using TransportSystems.Frontend.External.Interfaces;
using TransportSystems.Frontend.External.Interfaces.Addresses;
using TransportSystems.Frontend.External.Models.Geo;
using Xunit;

namespace TransportSystems.Frontend.Core.UnitTests.Infrastructure.Http.Addresses
{
    public class AddressesRepositoryTests
    {
        public AddressesRepositoryTests()
        {
            Suite = new AddressesRepositoryTestSuite();
        }

        protected AddressesRepositoryTestSuite Suite { get; }

        [Fact]
        public async Task GetAddresses()
        {
            var request = "Москв";
            
            var externalResult = new AddressEM();
            var externalListResult = new List<AddressEM> { externalResult };

            Suite.AddressAPIMock
                .Setup(m => m.GetAddress(request))
                .ReturnsAsync(externalListResult);

            var domainResult = new AddressDM();
            var domainListResult = new List<AddressDM> { domainResult };

            Suite.MappingServiceMock
                .Setup(m => m.Map<ICollection<AddressEM>, ICollection<AddressDM>>(externalListResult))
                .Returns(domainListResult);

            var addresses = await Suite.AddressesRepository.GetAddresses(request, RequestPriority.UserInitiated);

            Suite.AddressAPIMock
                .Verify(m => m.GetAddress(request), Times.Once);

            Suite.MappingServiceMock
                .Verify(
                    m => m.Map<ICollection<AddressEM>, ICollection<AddressDM>>(
                        It.Is<List<AddressEM>>(l => l.Equals(externalListResult))),
                    Times.Once);

            Assert.Equal(domainListResult, addresses);
        }

        [Fact]
        public async Task GetAddressByCoordinate()
        {
            var latitude = .0f;
            var longitude = .0f;
            
            var externalResult = new AddressEM();
            var externalListResult = new List<AddressEM> { externalResult };

            Suite.AddressAPIMock
                .Setup(m => m.GetAddressByCoordinate(latitude, longitude))
                .ReturnsAsync(externalListResult);

            var domainResult = new AddressDM();
            var domainListResult = new List<AddressDM> { domainResult };

            Suite.MappingServiceMock
                .Setup(m => m.Map<ICollection<AddressEM>, ICollection<AddressDM>>(externalListResult))
                .Returns(domainListResult);

            var addresses = await Suite.AddressesRepository.GetAddressesByCoordinate(latitude, longitude, RequestPriority.UserInitiated);

            Suite.AddressAPIMock
                .Verify(m => m.GetAddressByCoordinate(latitude, longitude), Times.Once);

            Suite.MappingServiceMock
                .Verify(
                    m => m.Map<ICollection<AddressEM>, ICollection<AddressDM>>(
                        It.Is<List<AddressEM>>(l => l.Equals(externalListResult))),
                    Times.Once);

            Assert.Equal(domainListResult, addresses);
        }

        protected class AddressesRepositoryTestSuite
        {
            public AddressesRepositoryTestSuite()
            {
                APIManagerMock = new Mock<IAPIManager>();
                MappingServiceMock = new Mock<IMappingService>();
                AddressesRepository = new AddressRepository(APIManagerMock.Object, MappingServiceMock.Object);

                AddressAPIMock = new Mock<IAddressesAPI>();

                APIManagerMock
                    .Setup(m => m.Get<IAddressesAPI>((External.Models.Models.RequestPriority)RequestPriority.UserInitiated))
                    .Returns(AddressAPIMock.Object);
            }

            public Mock<IAPIManager> APIManagerMock { get; }

            public Mock<IMappingService> MappingServiceMock { get; }

            public IAddressRepository AddressesRepository { get; }

            public Mock<IAddressesAPI> AddressAPIMock { get; }
        }
    }
}