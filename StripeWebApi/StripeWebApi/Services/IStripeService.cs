using StripeWebApi.Resources;

namespace StripeWebApi.Services;

public interface IStripeService
{
	Task<CustomerResource> CreateCustomer(CreateCustomerResource resource, CancellationToken cancellationToken);
	Task<ChargeResource> CreateCharge(CreateChargeResource resource, CancellationToken cancellationToken);
}