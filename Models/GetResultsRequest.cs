using System;

namespace Models
{
    public class GetResultsRequest
    {
        public string SessionId { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string Currency { get; set; }

    }

    public class PagingInfo
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }


}