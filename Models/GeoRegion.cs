using System;

namespace Models
{
    public abstract class GeoRegion
    {

    }

    public class Circle : GeoRegion
    {
        public GeoCode Center { get; set; }

        public double RadiusKm { get; set; }
    }

    public class GeoCode
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}