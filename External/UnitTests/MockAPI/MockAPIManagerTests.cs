using TransportSystems.Frontend.External.Interfaces;
using TransportSystems.Frontend.External.MockAPI;
using TransportSystems.Frontend.External.Models.Models;
using Xunit;

namespace TransportSystems.Frontend.External.UnitTests.MockAPI
{
    public class MockAPIManagerTestSuite
    {
        public MockAPIManagerTestSuite()
        {
            APIManager = new MockAPIManager();
        }

        public IAPIManager APIManager { get; }
    }

    public class MockAPIManagerTests
    {
        public MockAPIManagerTests()
        {
            Suite = new MockAPIManagerTestSuite();
        }

        protected MockAPIManagerTestSuite Suite { get; }
        
        [Fact]
        public void Get()
        {
            var api = Suite.APIManager.Get<IAPI>(RequestPriority.UserInitiated);
        
            Assert.NotNull(api);
            Assert.True(api is IAPI);
        }
    }
}