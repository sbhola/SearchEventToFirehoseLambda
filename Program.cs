using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.KinesisFirehose;
using Amazon.KinesisFirehose.Model;
using Amazon.Runtime;
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

        public async Task SearchEventHandler(Stream inputStream)
        {
            SearchEvent eventEntry;
            using (var reader = new StreamReader(inputStream))
            {
                eventEntry = Deserialize(reader);
            }

            var webCaller = new EngineWebCaller();
            var hotels = await webCaller.GetSearchResults(Extensions.ToGetResultsRequest(eventEntry));
            var searchDetails = Extensions.GetInitSearchRequestDetails(eventEntry);
            var resultDetails = Extensions.GetInitSearchResultDetails(hotels);

            var firehoseClient = new FirehoseClient();

            await firehoseClient.InsertSearchRequestDetails(searchDetails);

            foreach (var result in resultDetails)
            {
                result.SessionId = searchDetails.SessionId;
                await firehoseClient.InsertSearchResultDetails(result);
            }
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
