using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;
using RazorPaymentIntegration.Models;

namespace RazorPaymentIntegration.Controllers
{
	public class OrderController : Controller
	{
		[BindProperty]
		public OrderEntity _OrderDetails { get; set; }
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult InitiateOrder()
		{
			string key = "rzp_test_ZUzHdz7NmEZuvG";
			string secret = "Rfg0bhlzOTa0dlrETROphZNl";

			Random _random = new Random();
			string TransactionId = _random.Next(0, 10000).ToString();

			Dictionary<string, object> input = new Dictionary<string, object>();

			//_OrderDetails = new OrderEntity();

			//decimal totalAmount = Convert.ToDecimal(_OrderDetails.TotalAmount);

			//// Set a minimum amount of 1.00 INR
			//if (totalAmount < 1.00M)
			//{
			//	totalAmount = 1.00M;
			//	// You can also display an error message to the user if needed.
			//}

			//Dictionary<string, object> input = new Dictionary<string, object>();
			//input.Add("amount", Convert.ToDecimal(_OrderDetails.TotalAmount)*100);

			input.Add("amount", Convert.ToDecimal(_OrderDetails.TotalAmount) * 100);
			input.Add("currency", "INR");
			input.Add("receipt", TransactionId);

			RazorpayClient client = new RazorpayClient(key, secret);
			Razorpay.Api.Order order = client.Order.Create(input);

			ViewBag.orderid = order["id"].ToString();

			return View("Payment", _OrderDetails);

		}

		public IActionResult Payment(string razorpay_payment_id, string razorpay_order_id,
			string razorpay_signature)
		{
			Dictionary<string, string> attributes = new Dictionary<string, string>();
			attributes.Add("razorpay_payment_id", razorpay_payment_id);
			attributes.Add("razorpay_order_id", razorpay_order_id);
			attributes.Add("razorpay_signature", razorpay_signature);

			Utils.verifyPaymentSignature(attributes);

			OrderEntity orderdetails = new OrderEntity();

			orderdetails.TransactionId = razorpay_payment_id;
			orderdetails.OrderId = razorpay_order_id;

			return View("PaymentSuccess", orderdetails);

		}
	}
}