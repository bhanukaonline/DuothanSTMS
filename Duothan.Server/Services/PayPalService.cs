using Duothan.Server.Model;
using PayPal.Api;

namespace Duothan.Server.Services
{
    public class PayPalService
    {
        private readonly IConfiguration _configuration;

        public PayPalService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest paymentRequest)
        {
            var environment = new SandboxEnvironment(
                _configuration["PayPal:ClientId"],
                _configuration["PayPal:ClientSecret"]);
            var client = new PayPalHttpClient(environment);

            var payment = new Payment
            {
                Intent = "sale",
                Transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        Description = paymentRequest.Description,
                        Amount = new Amount
                        {
                            Total = paymentRequest.Amount.ToString(),
                            Currency = paymentRequest.Currency
                        }
                    }
                },
                RedirectUrls = new RedirectUrls
                {
                    CancelUrl = "https://example.com/cancel",
                    ReturnUrl = "https://example.com/return"
                },
                Payer = new Payer { PaymentMethod = "paypal" }
            };

            var createdPayment = await client.Execute(new PaymentCreateRequest().RequestBody(payment));

            var approvalUrl = createdPayment.Links.FirstOrDefault(link => link.Rel.Equals("approval_url", StringComparison.OrdinalIgnoreCase));

            return new PaymentResponse
            {
                Success = approvalUrl != null,
                Message = approvalUrl?.Href ?? "Payment failed",
                TransactionId = createdPayment.Id
            };
        }
    }
}
