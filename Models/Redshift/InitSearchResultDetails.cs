using System;

namespace Models
{
    public class HotelSearchResult
    {
        //public Int64 Id { get; set; }
        public string SessionId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string HotelId { get; set; }
        public string ContentSupplierFamily { get; set; }
        public string HotelName { get; set; }
        public string HotelChain { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public float Rating { get; set; }
        public string SelectedRateSupplierId { get; set; }
        public decimal? SupplierRate { get; set; }
        public decimal? Markup { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TotalFare { get; set; }
        public decimal? BaseFare { get; set; }
        public string DisplayCurrency { get; set; }
        public string SupplierCurrency { get; set; }

    }
}

