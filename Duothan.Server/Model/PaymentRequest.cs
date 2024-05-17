namespace Duothan.Server.Model
{
    public class PaymentRequest
    {
        public string PaymentMethod { get; set; } // "Stripe" or "PayPal"
        public decimal Amount { get; set; }
        public string Currency { get; set; } // e.g., "usd", "eur"
        public string Description { get; set; }
    }
}
