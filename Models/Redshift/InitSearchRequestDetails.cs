using System;

namespace Models
{
    public class HotelSearchRequestDetails
    {
        //public Int64 Id { get; set; }
        public string SessionId { get; set; }
        public string CorrelationId { get; set; }
        public string PosId { get; set; }
        public string TenantId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public Int16 RoomsCount { get; set; }
        public Int16 AdultCount { get; set; }
        public Int16 ChildCount { get; set; }
        public Int16 LeadTime { get; set; }
        public string BoundType { get; set; }
        public string TravellerNationalityCode { get; set; }
        public string TravellerCountryCodeOfResidence { get; set; }
        public string Currency { get; set; }
        public string CustomerIpAddress { get; set; }
        public string Source { get; set; }
        public double? CircleCenterLatitude { get; set; }
        public double? CircleCenterLongitude { get; set; }
        public Int16? CircleRadius { get; set; }
        public double? TopLeftLatitude { get; set; }
        public double? TopLeftLongitude { get; set; }
        public double? BottomRightLatitude { get; set; }
        public double? BottomRightLongitude { get; set; }

    }

}