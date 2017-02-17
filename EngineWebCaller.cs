using WebClient;
using Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System;

namespace SearchLambdaFunction
{
    public class EngineWebCaller
    {
        private static WebCaller _webClient = new WebCaller(1000000);

        public async Task GetSearchResults(GetResultsRequest request)
        {
            var requestMessage = GetSearchResultsRequestMessage(request);

            var response = await _webClient.PostAsync(requestMessage);

            Console.ReadKey();
        }

        private WebClientRequestMessage GetSearchResultsRequestMessage(GetResultsRequest request)
        {
            var requestMessage = new WebClientRequestMessage();
            requestMessage.Url = "https://public-be.stage.oski.io/hotel/v1.0/search/results";
            requestMessage.Data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request));
            requestMessage.ContentHeaders.Add(Constants.Headers.ContentType, Constants.HeaderValues.ContentType);
            requestMessage.RequestHeaders.Add(Constants.Headers.OskiTenantId, Constants.HeaderValues.OskiTenantId);
            return requestMessage;
        }



    }

}