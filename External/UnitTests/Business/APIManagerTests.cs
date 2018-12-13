using TransportSystems.Frontend.External.Business;
using TransportSystems.Frontend.External.Interfaces;
using TransportSystems.Frontend.External.Models.Models;
using Xunit;

namespace TransportSystems.Frontend.External.UnitTests.Business
{
    public class APIManagerTestSuite
    {
        public APIManagerTestSuite()
        {
            APIManager = new APIManager("http://test.ru", new System.Net.Http.HttpClientHandler());
        }

        public IAPIManager APIManager { get; }
    }

    public class APIManagerTests
    {
        public APIManagerTests()
        {
            Suite = new APIManagerTestSuite();
        }

        protected APIManagerTestSuite Suite { get; }

        [Fact]
        public void Get()
        {
            var api = Suite.APIManager.Get<IAPI>(RequestPriority.UserInitiated);

            Assert.NotNull(api); 
        }
    }
}
