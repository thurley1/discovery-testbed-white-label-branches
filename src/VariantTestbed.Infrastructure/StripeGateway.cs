using VariantTestbed.Domain.Payments;

namespace VariantTestbed.Infrastructure.Gateways;

public class StripeGateway : IPaymentGateway
{
    public Task<string> ChargeAsync(decimal amount, string currency, CancellationToken ct = default)
    {
        return Task.FromResult($"stripe_txn_{Guid.NewGuid():N}");
    }

    public Task RefundAsync(string transactionId, CancellationToken ct = default)
    {
        return Task.CompletedTask;
    }
}
