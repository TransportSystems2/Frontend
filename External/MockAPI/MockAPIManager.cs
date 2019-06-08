using System;
using System.Linq;
using TransportSystems.Frontend.External.Interfaces;
using TransportSystems.Frontend.External.Models.Models;

namespace TransportSystems.Frontend.External.MockAPI
{
    public class MockAPIManager : IAPIManager
    {
        public T Get<T>(RequestPriority priority)
        {
            var type = typeof(T);
            var types = typeof(MockAPIManager).Assembly.GetTypes();
            var creatingType = types.First(t => t.GetInterface(typeof(T).FullName) != null);
            var instance = (T)Activator.CreateInstance(creatingType);

            return instance;
        }
    }
}
