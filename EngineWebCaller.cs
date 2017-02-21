using WebClient;
using Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System;
using System.Collections.Generic;
using Models.Request;
using Models.Response;
using Newtonsoft.Json.Serialization;

namespace SearchLambdaFunction
{
    public class EngineWebCaller
    {
        private static WebCaller _webClient = new WebCaller(1000000);

        public async Task<List<Hotel>> GetSearchResults(GetResultsRequest request)
        {
            return await GetAllPaginatedResults(request);
        }

        private async Task<List<Hotel>> GetAllPaginatedResults(GetResultsRequest request)
        {
            request.Paging = new Models.Request.Paging();
            request.Paging.PageNo = 1;
            request.Paging.PageSize = 200; // should come from constants//config

            var hotels = new List<Hotel>();
            var moreResults = true;

            while (moreResults)
            {
                var requestMessage = GetSearchResultsRequestMessage(request);

                var webResponse = await _webClient.PostAsync(requestMessage);

                var result = GetSearchResultsResponse(webResponse);

                if (result.hotels != null && result.hotels.Count > 0)
                {
                    hotels.AddRange(result.hotels);
                    request.Paging.PageNo++;
                }
                else
                {
                    moreResults = false;
                }
            }
            return hotels;
        }

        private WebClientRequestMessage GetSearchResultsRequestMessage(GetResultsRequest request)
        {
            var requestMessage = new WebClientRequestMessage();
            requestMessage.Url = Constants.SearchResultsUrls.StageUrl;
            requestMessage.Data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request, Formatting.Indented,
            new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
            requestMessage.ContentHeaders.Add(Constants.Headers.ContentType, Constants.HeaderValues.ContentType);
            requestMessage.RequestHeaders.Add(Constants.Headers.OskiTenantId, Constants.HeaderValues.OskiTenantId);
            return requestMessage;
        }

        private GetResultsResponse GetSearchResultsResponse(WebClientResponseMessage responseMessage)
        {
            var responseJson = Encoding.UTF8.GetString(responseMessage.Data);
            var response = JsonConvert.DeserializeObject<GetResultsResponse>(responseJson);
            return response;
        }

    }

}