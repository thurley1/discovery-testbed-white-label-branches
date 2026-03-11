namespace VariantTestbed.Domain.Payments;

public interface IPaymentGateway
{
    Task<string> ChargeAsync(decimal amount, string currency, CancellationToken ct = default);
    Task RefundAsync(string transactionId, CancellationToken ct = default);
}
