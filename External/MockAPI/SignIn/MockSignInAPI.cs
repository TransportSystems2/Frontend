using System;
using System.Threading.Tasks;
using TransportSystems.Frontend.External.Models.SignIn;
using TransportSystems.Frontend.External.SignIn;

namespace TransportSystems.Frontend.External.MockAPI.SignIn
{
    public class MockSignInAPI : ISignInAPI
    {
        public async Task<bool> CheckToken(IdentityTokenEM token)
        {
            await Task.Delay(1000);

            return true;
        }
    }
}
