namespace Duothan.Server.Model
{
    public class PublicTransportSchedule
    {
        public int ScheduleID { get; set; }
        public int RouteID { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
