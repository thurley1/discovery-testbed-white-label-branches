namespace VariantTestbed.Domain.Payments;

public class UmbrellaPaymentService : PaymentService
{
    public UmbrellaPaymentService(UmbrellaPaymentGateway gateway) : base(gateway) { }

    public async Task<Payment> ProcessWithComplianceAsync(Guid orderId, decimal amount, string userId, CancellationToken ct = default)
    {
        // Umbrella requires compliance logging for all payments over 10k
        if (amount > 10000)
        {
            Console.WriteLine($"[COMPLIANCE] High-value payment by {userId}: {amount:C}");
        }
        return await ProcessPaymentAsync(orderId, amount, ct);
    }
}
