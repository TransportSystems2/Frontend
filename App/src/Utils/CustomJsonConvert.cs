using System;
using System.IO;
using Newtonsoft.Json;
using TransportSystems.Frontend.Core.Domain.Interfaces.Utils;

namespace TransportSystems.Frontend.App.Utils
{
    public class CustomJsonConvert : IJsonConverter
    {
        public T DeserializeObject<T>(Stream stream)
        {
            throw new NotImplementedException();
        }

        public T DeserializeObject<T>(string inputText)
        {
            return JsonConvert.DeserializeObject<T>(inputText);
        }

        public object DeserializeObject(Type type, string inputText)
        {
            throw new NotImplementedException();
        }

        public string SerializeObject(object toSerialise)
        {
            throw new NotImplementedException();
        }
    }
}
