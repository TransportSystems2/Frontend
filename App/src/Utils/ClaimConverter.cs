using System;
using System.Security.Claims;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TransportSystems.Frontend.Core.Domain.Interfaces.Utils;

namespace TransportSystems.Frontend.App.Utils
{
    public class CustomClaimJsonConverter : CustomJsonConverter, IClaimJsonConverter
    {
        public new T DeserializeObject<T>(string inputText)
        {
            return JsonConvert.DeserializeObject<T>(inputText, new ClaimJsonConverter());
        }

        public new string SerializeObject(object toSerialise)
        {
            return JsonConvert.SerializeObject(toSerialise);
        }
    }

    public class ClaimJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Claim));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            string type = (string)jo["Type"];
            string value = (string)jo["Value"];
            string valueType = (string)jo["ValueType"];
            string issuer = (string)jo["Issuer"];
            string originalIssuer = (string)jo["OriginalIssuer"];
            return new Claim(type, value, valueType, issuer, originalIssuer);
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
