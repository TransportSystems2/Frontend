using System;
using System.IO;

namespace TransportSystems.Frontend.Core.Domain.Interfaces.Utils
{
    public interface IJsonConverter
    {
        T DeserializeObject<T>(Stream stream);

        T DeserializeObject<T>(string inputText);

        string SerializeObject(object toSerialise);

        object DeserializeObject(Type type, string inputText);
    }
}
