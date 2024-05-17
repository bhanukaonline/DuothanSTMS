namespace Duothan.Server.Model
{
    public class TransportPass
    {
        public int TransportPassID { get; set; }
        public int UserID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public decimal Balance { get; set; }
    }
}
