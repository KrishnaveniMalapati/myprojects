using Microsoft.AspNetCore.Mvc;
using PaymentMethod.Models;

namespace PaymentMethod.Controller
{
    public class PaymentController: ControllerBase
    {
        [HttpGet]
        public IActionResult PaymentForm()
        {
            return Content("Payment processed successfully!");

        }

        [HttpPost]
        public IActionResult ProcessPayment(CardDetails cardDetails)
        {
            if (!ModelState.IsValid)
            {
                return View("PaymentForm", cardDetails);
            }

            // Here, you can use the cardDetails object to process the payment.
            // You may want to integrate with a payment gateway, validate the card details,
            // and perform the payment transaction.

            // For demonstration purposes, you can simply return a success message.
            return Content("Payment processed successfully!");
        }

        private IActionResult View(string v, CardDetails cardDetails)
        {
            throw new NotImplementedException();
        }
    }
    
}
