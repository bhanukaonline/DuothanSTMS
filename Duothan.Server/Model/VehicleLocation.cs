namespace Duothan.Server.Model
{
    public class VehicleLocation
    {
        public int VehicleID { get; set; }
        public int RouteID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
