using Duothan.Server.Model;
using Stripe;

namespace Duothan.Server.Services
{
    public class StripeService
    {
        private readonly IConfiguration _configuration;

        public StripeService(IConfiguration configuration)
        {
            _configuration = configuration;
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
        }

        public async Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest paymentRequest)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(paymentRequest.Amount * 100), // Convert to cents
                Currency = paymentRequest.Currency,
                PaymentMethodTypes = new List<string> { "card" },
                Description = paymentRequest.Description
            };

            var service = new PaymentIntentService();
            var paymentIntent = await service.CreateAsync(options);

            return new PaymentResponse
            {
                Success = paymentIntent.Status == "succeeded",
                Message = paymentIntent.Status,
                TransactionId = paymentIntent.Id
            };
        }
    }
}
