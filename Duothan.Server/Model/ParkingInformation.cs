namespace Duothan.Server.Model
{
    public class ParkingInformation
    {
        public int ParkingID { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public int AvailableSpots { get; set; }
    }
}
