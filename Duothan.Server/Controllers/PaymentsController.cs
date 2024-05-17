using Duothan.Server.Model;
using Duothan.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Duothan.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly StripeService _stripeService;
        private readonly PayPalService _paypalService;

        public PaymentsController(StripeService stripeService, PayPalService paypalService)
        {
            _stripeService = stripeService;
            _paypalService = paypalService;
        }

        [HttpPost("process")]
        public async Task<ActionResult<PaymentResponse>> ProcessPayment([FromBody] PaymentRequest paymentRequest)
        {
            PaymentResponse paymentResponse;

            if (paymentRequest.PaymentMethod == "Stripe")
            {
                paymentResponse = await _stripeService.ProcessPaymentAsync(paymentRequest);
            }
            else if (paymentRequest.PaymentMethod == "PayPal")
            {
                paymentResponse = await _paypalService.ProcessPaymentAsync(paymentRequest);
            }
            else
            {
                return BadRequest("Invalid payment method.");
            }

            if (paymentResponse.Success)
            {
                return Ok(paymentResponse);
            }
            else
            {
                return StatusCode(500, paymentResponse);
            }
        }
    }
}
