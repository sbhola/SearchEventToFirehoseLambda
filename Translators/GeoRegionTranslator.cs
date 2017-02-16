using System;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Translators
{
    public class GeoRegionTranslator : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(GeoRegion);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            if (jo["Center"].HasValues)
                return jo.ToObject<Circle>(serializer);

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

}