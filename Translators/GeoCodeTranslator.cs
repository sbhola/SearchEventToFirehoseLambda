using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Models;

namespace Translators
{
    public class GeoCodeTranslator : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(GeoCode);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            var lat = jo["Latitude"].Value<double>();
            var lon = jo["Longitude"].Value<double>();

            var geocode = new GeoCode();
            geocode.Latitude = lat;
            geocode.Longitude = lon;
            return geocode;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}