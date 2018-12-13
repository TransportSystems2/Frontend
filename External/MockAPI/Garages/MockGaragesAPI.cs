using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransportSystems.Frontend.External.Garages;

namespace TransportSystems.Frontend.External.MockAPI.Garages
{
    public class MockGaragesAPI : IGaragesAPI
    {
        public MockGaragesAPI(int delay)
        {
            Delay = delay;
        }

        protected int Delay { get; }

        public async Task<ICollection<string>> GetAvailableDistricts(string country, string province, string locality)
        {
            await Task.Delay(Delay);
            ICollection<string> result = new List<string>
            {
                "Центральный",
                "Северный",
                "Западный"
            };

            return result;
        }

        public async Task<ICollection<string>> GetAvailableLocalities(string country, string province)
        {
            await Task.Delay(1000);
            ICollection<string> result = new List<string>
            {
                "Ярославль",
                "Рыбинск",
                "Тутаев"
            };

            return result;
        }

        public async Task<ICollection<string>> GetAvailableProvinces(string country)
        {
            await Task.Delay(Delay);
            ICollection<string> result = new List<string>
            {
                "Московская",
                "Ярославская",
                "Воронежская"
            };

            return result;
        }
    }
}
