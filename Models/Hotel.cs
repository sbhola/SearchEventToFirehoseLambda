using System;
using System.Collections.Generic;

namespace Models
{
    public class Hotel
    {
        public string id { get; set; }
        public Source source { get; set; }
        public string contentSupplierFamily { get; set; }
        public string hotelCurrencyCode { get; set; }
        public Contact contact { get; set; }
        public HotelGeoCode geoCode { get; set; }
        public string name { get; set; }
        public double rating { get; set; }
        public bool supportsPrepaidRates { get; set; }
        public bool supportsPostpaidRates { get; set; }
        public Fare fare { get; set; }
        public List<RoomOccupancy> roomOccupancies { get; set; }
        public List<Room> rooms { get; set; }
        public Rates rates { get; set; }
        public HotelChain hotelChain { get; set; }

    }

    public class HotelChain
    {

        public string Name { get; }

        public string Url { get; set; }
    }

    public class Source
    {
        public string selectedSupplier { get; set; }
        public List<string> suppliers { get; set; }
    }

    public class Room
    {
        public string refId { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
        public string code { get; set; }
        public string roomTypeCode { get; set; }
        public int availableRoomCount { get; set; }
        public string smokingIndicator { get; set; }
        public List<BedDetail> bedDetails { get; set; }
        public List<object> roomViews { get; set; }
    }

    public class BedDetail
    {
        public string type { get; set; }
        public int count { get; set; }
        public string desc { get; set; }
    }

    public class Fare
    {
        public double baseFare { get; set; }
        public string currency { get; set; }
        public List<object> fees { get; set; }
        public List<object> discounts { get; set; }
        public List<object> taxes { get; set; }
        public double totalFare { get; set; }
    }

}
