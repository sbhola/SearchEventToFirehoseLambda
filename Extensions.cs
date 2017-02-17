using Models;

namespace SearchLambdaFunction
{
    public static class Extensions
    {
        public static GetResultsRequest ToGetResultsRequest(SearchEvent eventEntry)
        {
            var request = new GetResultsRequest();
            request.SessionId = eventEntry.HotelSearchQuery.SessionId;
            request.Currency = eventEntry.HotelSearchQuery.Currency;
            request.PagingInfo = new PagingInfo();
            request.PagingInfo.PageNumber = 1;
            request.PagingInfo.PageSize = 100;
            return request;
        }

    }
}