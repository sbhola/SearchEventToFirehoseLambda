using System;
using System.IO;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;
using Translators;

namespace SearchLambdaFunction
{
    public class EventHandler
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!");
            Task.Run(async () =>
            {
                using (var stream = new FileStream($"{Directory.GetCurrentDirectory()}\\TestData.json", FileMode.Open))
                {
                    await new EventHandler().SearchEventHandler(stream);
                }
            }).GetAwaiter().GetResult();
        }

        public async Task<Stream> SearchEventHandler(Stream inputStream)
        {
            SearchEvent eventEntry;
            using (var reader = new StreamReader(inputStream))
            {
                eventEntry = Deserialize(reader);
            }
            Console.WriteLine(eventEntry.CorrelationId);
            var webCaller = new EngineWebCaller();
            await webCaller.GetSearchResults(Extensions.ToGetResultsRequest(eventEntry));

            //ToDo:
            //Call BE search results paginated
            //parse it to data models for firehose streams
            //push data to firehose

            return inputStream;
        }

        private SearchEvent Deserialize(TextReader reader)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            JsonConverter[] converters = { new GeoRegionTranslator(), new CircleTranslator(), new GeoCodeTranslator() };
            settings.Converters = converters;
            return JsonConvert.DeserializeObject<SearchEvent>(reader.ReadToEnd(), settings);

        }

    }
}
