using System;
using System.Collections.Generic;

namespace Models
{
    public class SearchEvent
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public DateTime TimeStamp { get; set; }

        public string CorrelationId { get; set; }
        public HotelSearchQuery HotelSearchQuery { get; set; }
        public bool IsSearchPartial { get; set; }
        public double TimeTakenInMilliSec { get; set; }
    }

}