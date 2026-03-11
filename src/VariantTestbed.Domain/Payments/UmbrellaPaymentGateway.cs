namespace VariantTestbed.Domain.Payments;

public class UmbrellaPaymentGateway : IPaymentGateway
{
    private readonly string _merchantId;
    private readonly string _apiKey;

    public UmbrellaPaymentGateway(string merchantId, string apiKey)
    {
        _merchantId = merchantId;
        _apiKey = apiKey;
    }

    public Task<string> ChargeAsync(decimal amount, string currency, CancellationToken ct = default)
    {
        // Umbrella-specific payment routing with their banking partner
        var txnId = $"umb_{_merchantId}_{Guid.NewGuid():N}";
        return Task.FromResult(txnId);
    }

    public Task RefundAsync(string transactionId, CancellationToken ct = default)
    {
        return Task.CompletedTask;
    }
}
