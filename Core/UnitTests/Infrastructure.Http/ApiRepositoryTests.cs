using Moq;
using TransportSystems.Frontend.Core.Domain.Core;
using TransportSystems.Frontend.Core.Infrastructure.Http;
using TransportSystems.Frontend.External.Interfaces;
using Xunit;

namespace TransportSystems.Frontend.Core.UnitTests.Infrastructure.Http
{
    public class ApiRepositoryTests
    {
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

            public Mock<IAPI> APIMock { get; }
        }
    }
}