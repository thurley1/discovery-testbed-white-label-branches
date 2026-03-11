namespace VariantTestbed.Domain.Payments;

public class Payment
{
    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentStatus Status { get; private set; }
    public string Gateway { get; private set; } = "Stripe";
    public string? TransactionId { get; private set; }

    public static Payment Create(Guid orderId, decimal amount, string gateway = "Stripe")
    {
        return new Payment
        {
            Id = Guid.NewGuid(),
            OrderId = orderId,
            Amount = amount,
            Gateway = gateway,
            Status = PaymentStatus.Pending
        };
    }

    public void MarkSuccessful(string transactionId) { Status = PaymentStatus.Successful; TransactionId = transactionId; }
    public void MarkFailed() => Status = PaymentStatus.Failed;
    public void Refund() => Status = PaymentStatus.Refunded;
}
