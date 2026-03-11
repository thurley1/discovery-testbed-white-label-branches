namespace VariantTestbed.Domain.Payments;

public class PaymentService
{
    private readonly IPaymentGateway _gateway;

    public PaymentService(IPaymentGateway gateway) => _gateway = gateway;

    public async Task<Payment> ProcessPaymentAsync(Guid orderId, decimal amount, CancellationToken ct = default)
    {
        var payment = Payment.Create(orderId, amount);
        try
        {
            var txnId = await _gateway.ChargeAsync(amount, "USD", ct);
            payment.MarkSuccessful(txnId);
        }
        catch
        {
            payment.MarkFailed();
        }
        return payment;
    }
}
