using System;
using Newtonsoft.Json;
using Models;
using Newtonsoft.Json.Linq;

namespace Translators
{
    public class CircleTranslator : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Circle);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            var radius = jo["RadiusKm"].Value<double>();
            var center = jo["Center"].ToObject<GeoCode>(serializer);

            var circle = new Circle();
            circle.Center = center;
            circle.RadiusKm = radius;
            return circle;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

