using System;

namespace Models.Request
{
    public class GetResultsRequest
    {
        public string SessionId { get; set; }

        public Paging Paging { get; set; }

        public string Currency { get; set; }

    }

    public class Paging
    {
        public int PageNo { get; set; }

        public int PageSize { get; set; }
    }


}