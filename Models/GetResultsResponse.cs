using System;
using System.Collections.Generic;

namespace Models.Response
{
    public class GetResultsResponse
    {
        public string SessionId { get; set; }
        public string Currency { get; set; }
        public List<Hotel> hotels { get; set; }
        public Paging paging { get; set; }
    }

    public class Paging
    {
        public int TotalRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}