using Models;
using Models.Request;
using System.Linq;
using System;
using System.Collections.Generic;

namespace SearchLambdaFunction
{
    public static class Extensions
    {
        public static GetResultsRequest ToGetResultsRequest(SearchEvent eventEntry)
        {
            var request = new GetResultsRequest();
            request.SessionId = eventEntry.HotelSearchQuery.SessionId;
            request.Currency = eventEntry.HotelSearchQuery.Currency;
            request.Paging = new Paging();
            request.Paging.PageNo = 1;
            request.Paging.PageSize = 100;
            return request;
        }

        public static HotelSearchRequestDetails GetInitSearchRequestDetails(SearchEvent eventEntry)
        {
            var requestDetails = new HotelSearchRequestDetails();
            requestDetails.SessionId = eventEntry.HotelSearchQuery.SessionId;
            requestDetails.CreatedOn = eventEntry.TimeStamp;
            requestDetails.CorrelationId = eventEntry.CorrelationId;
            requestDetails.PosId = eventEntry.HotelSearchQuery.PosId;
            requestDetails.TenantId = eventEntry.HotelSearchQuery.TenantId;
            requestDetails.Currency = eventEntry.HotelSearchQuery.Currency;
            requestDetails.CheckInDate = eventEntry.HotelSearchQuery.StayPeriod.Start;
            requestDetails.CheckOutDate = eventEntry.HotelSearchQuery.StayPeriod.End;
            requestDetails.AdultCount = (Int16)eventEntry.HotelSearchQuery.RoomOccupancies.Sum(x => x.Occupants.Count(y => y.Type == OccupantType.Adult));
            requestDetails.ChildCount = (Int16)eventEntry.HotelSearchQuery.RoomOccupancies.Sum(x => x.Occupants.Count(y => y.Type == OccupantType.Child));
            requestDetails.LeadTime = (Int16)(DateTime.UtcNow.Date - eventEntry.HotelSearchQuery.StayPeriod.Start.Date).Days;
            requestDetails.TravellerNationalityCode = eventEntry.HotelSearchQuery.TravellerNationalityCode;
            requestDetails.TravellerCountryCodeOfResidence = eventEntry.HotelSearchQuery.TravellerCountryCodeOfResidence;

            var circle = eventEntry.HotelSearchQuery.Bounds as Circle;
            if (circle != null && circle.Center != null)
            {
                requestDetails.CircleCenterLatitude = circle.Center?.Latitude;
                requestDetails.CircleCenterLongitude = circle.Center?.Longitude;
                requestDetails.CircleRadius = (Int16)circle.RadiusKm;
                requestDetails.BoundType = "Circle";
            }
            return requestDetails;
        }

        public static List<HotelSearchResult> GetInitSearchResultDetails(List<Hotel> hotels)
        {
            var resultDetails = new List<HotelSearchResult>();
            foreach (var hotel in hotels)
            {
                var hotelDetails = new HotelSearchResult();
                hotelDetails.HotelName = hotel.name;
                hotelDetails.HotelId = hotel.id;
                hotelDetails.AddressLine1 = hotel.contact?.address?.line1;
                hotelDetails.City = hotel.contact?.address?.city.name;
                hotelDetails.State = hotel.contact?.address?.state.name;
                hotelDetails.CountryCode = hotel.contact?.address?.countryCode;
                hotelDetails.ContentSupplierFamily = hotel.contentSupplierFamily;
                hotelDetails.CreatedOn = DateTime.UtcNow;
                hotelDetails.HotelChain = hotel.hotelChain?.Name;
                hotelDetails.Latitude = hotel.geoCode?.lat;
                resultDetails.Add(hotelDetails);
            }
            return resultDetails;
        }

    }
}