using System;
using System.Threading.Tasks;
using Refit;
using TransportSystems.Frontend.External.Models.SignUp;
using TransportSystems.Frontend.External.SignUp;

namespace TransportSystems.Frontend.External.MockAPI.SignUp
{
    public class MockSignUpAPI : ISignUpAPI
    {
        public MockSignUpAPI()
        {
        }

        public async Task RegisterDispatcher([Body(BodySerializationMethod.Json)] DispatcherCompanyEM dispatcherCompany)
        {
            await Task.Delay(1000);
        }

        public async Task RegisterDriver([Body(BodySerializationMethod.Json)] DriverCompanyEM driverCompany)
        {
            await Task.Delay(1000);
        }
    }
}
