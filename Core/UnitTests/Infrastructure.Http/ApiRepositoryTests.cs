using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using TransporSystems.Frontend.Utils.Mapping;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Domain.Core.Geo;
using TransportSystems.Frontend.Core.Domain.Interfaces.Address;
using TransportSystems.Frontend.Core.Infrastructure.Http;
using TransportSystems.Frontend.Core.Infrastructure.Http.Addresses;
using TransportSystems.Frontend.External.Interfaces;
using TransportSystems.Frontend.External.Interfaces.Addresses;
using TransportSystems.Frontend.External.Models.Geo;
using Xunit;

namespace TransportSystems.Frontend.Core.UnitTests.Infrastructure.Http
{
    public class ApiRepositoryTests
    {
        public class ApiRepositoryTestSuite
        {
            public ApiRepositoryTestSuite()
            {
                APIManagerMock = new Mock<IAPIManager>();
                ApiRepository = new ApiRepository<IAPI>(APIManagerMock.Object);

                APIMock = new Mock<IAPI>();
            }

            public Mock<IAPIManager> APIManagerMock { get; }

            public ApiRepository<IAPI> ApiRepository { get; }

            public Mock<IAPI> APIMock {get;}
        }

        public ApiRepositoryTests()
        {
            Suite = new ApiRepositoryTestSuite();
        }

        protected ApiRepositoryTestSuite Suite { get; }

        [Fact]
        public void Get()
        {
            var priority = RequestPriority.UserInitiated;

            Suite.APIManagerMock
                .Setup(m => m.Get<IAPI>((External.Models.Models.RequestPriority)priority))
                .Returns(Suite.APIMock.Object);

            var api = Suite.ApiRepository.GetApi(priority);

            Suite.APIManagerMock
                .Verify(m => m.Get<IAPI>((External.Models.Models.RequestPriority)priority), Times.Once);

            Assert.Equal(Suite.APIMock.Object, api);
        }
    }
}