namespace VariantTestbed.Domain.Orders;

public class Order
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public OrderStatus Status { get; private set; }
    public List<OrderLine> Lines { get; private set; } = new();
    public decimal Total => Lines.Sum(l => l.Quantity * l.UnitPrice);

    public static Order Create(Guid customerId)
    {
        return new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            CreatedAt = DateTime.UtcNow,
            Status = OrderStatus.Pending
        };
    }

    public void AddLine(string productName, int quantity, decimal unitPrice)
    {
        Lines.Add(new OrderLine(productName, quantity, unitPrice));
    }

    public void Submit() => Status = OrderStatus.Submitted;
    public void Complete() => Status = OrderStatus.Completed;
    public void Cancel() => Status = OrderStatus.Cancelled;
}
