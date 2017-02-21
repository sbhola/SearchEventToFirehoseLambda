using System.Collections.Generic;

namespace Models
{
    public class Rates
    {
        public List<PerBookingRate> perRoomRates { get; set; }
        public List<PerBookingRate> perBookingRates { get; set; }
    }

    public class PerBookingRate
    {
        public string refId { get; set; }
        public bool isPrepaid { get; set; }
        public string type { get; set; }
        public string supplierId { get; set; }
        public string supplierHotelId { get; set; }
        public bool depositRequired { get; set; }
        public bool guaranteeRequired { get; set; }
        public List<object> allowedCountries { get; set; }
        public List<object> allowedCreditCards { get; set; }
        public string code { get; set; }
        public string refundability { get; set; }
        public CancellationPolicy cancellationPolicy { get; set; }
        public List<object> policies { get; set; }
        public List<object> additionalCharges { get; set; }
        public List<object> inclusions { get; set; }
        public double baseFare { get; set; }
        public List<Tax> taxes { get; set; }
        public List<object> fees { get; set; }
        public int discount { get; set; }
        public double totalFare { get; set; }
        public List<RateOccupancy> rateOccupancies { get; set; }
        public BoardBasis boardBasis { get; set; }
    }

    public class RateOccupancy
    {
        public string roomRefId { get; set; }
        public string occupancyRefId { get; set; }
    }

    public class BoardBasis
    {
        public string desc { get; set; }
        public string type { get; set; }
    }

    public class CancellationPolicy
    {
        public string text { get; set; }
        public List<PenaltyRule> penaltyRules { get; set; }
    }

    public class Tax
    {
        public string desc { get; set; }
        public double amount { get; set; }
    }


    public class Window
    {
        public string start { get; set; }
        public string end { get; set; }
    }

    public class PenaltyRule
    {
        public Window window { get; set; }
        public double value { get; set; }
        public double estimatedValue { get; set; }
        public string valueType { get; set; }
    }
}