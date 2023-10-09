using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using StripePaymentMode.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StripePaymentMode.Controllers
{
	public class HomeController : Controller
	{
		private readonly StripeSettings _stripeSettings;
		// private StripeSettings _stripeSettings;

		public string SessionId { get; set; }

		public HomeController(IOptions<StripeSettings> stripeSettings)
		{
			_stripeSettings = stripeSettings.Value;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult CreateCheckoutSession(string amount)
		{
			var currency = "usd";
			var successUrl = "https://localhost:44342/Home/Success";
			var cancelUrl = "https://localhost:44342/Home/cancel";

			StripeConfiguration.ApiKey = _stripeSettings.SecretKey;

			var options = new SessionCreateOptions
			{
				PaymentMethodTypes = new List<string>
				{
					"card"
				},
				LineItems = new List<SessionLineItemOptions>
				{
					new SessionLineItemOptions
					{
						PriceData = new SessionLineItemPriceDataOptions
						{
							Currency = currency,
							UnitAmount = Convert.ToInt32(amount) * 100,
							ProductData = new SessionLineItemPriceDataProductDataOptions
							{
								Name = "Product Name",
								Description = "Product Description"
							}

						},

						Quantity = 1
					}
				},
				Mode = "payment",
				SuccessUrl = successUrl,
				CancelUrl = cancelUrl,
			};

			var service = new SessionService();

			var session = service.Create(options);


			SessionId = session.Id;

			return Redirect(session.Url);

		}

		public async Task<IActionResult> success()
		{
			return View("Index");

		}

		public IActionResult cancel()
		{
			return View("Index");
		}
	}
}
