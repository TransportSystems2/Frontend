using System;
using System.Threading.Tasks;
using TransportSystems.Frontend.External.Interfaces;

namespace TransportSystems.Frontend.External.MockAPI
{
    public class API : IAPI
    {
        public async Task<string> Get(string request)
        {
            await Task.Delay(1000);

            return "test";
        }
    }
}
