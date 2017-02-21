using System.Collections.Generic;

namespace Models
{
    public class Address
    {
        public string line1 { get; set; }
        public string line2 { get; set; }
        public City city { get; set; }
        public State state { get; set; }
        public string countryCode { get; set; }
        public string postalCode { get; set; }
    }

    public class City
    {
        public string name { get; set; }
        public string code { get; set; }
    }

    public class State
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Contact
    {
        public List<Phone> phones { get; set; }
        public Address address { get; set; }
    }

    public class Phone
    {
        public PhoneType Type { get; set; }
        public string Number { get; set; }
        public string CountryCode { get; set; }
        public string Extension { get; set; }
        public string AreaCode { get; set; }
    }

    public enum PhoneType
    {
        Unknown,
        Work,
        Home,
        Mobile,
        Fax
    }

    public class HotelGeoCode
    {
        public double lat { get; set; }
        public double @long { get; set; }
    }
}