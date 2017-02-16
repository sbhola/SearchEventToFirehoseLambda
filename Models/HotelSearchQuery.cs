using System;
using System.Collections.Generic;

namespace Models
{
    public class HotelSearchQuery
    {
        public GeoRegion Bounds { get; set; }

        public bool IncludeHotelsWithoutRates { get; set; }

        public string SessionId { get; set; }
        public string TenantId { get; set; }
        public string PosId { get; set; }
        public string Currency { get; set; }
        public StayPeriod StayPeriod { get; set; }
        public List<RoomOccupancy> RoomOccupancies { get; } = new List<RoomOccupancy>();
        public string TravellerCountryCodeOfResidence { get; set; }
        public string TravellerNationalityCode { get; set; }
        public string Culture { get; set; }
    }

}
