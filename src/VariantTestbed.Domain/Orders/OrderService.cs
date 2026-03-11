namespace VariantTestbed.Domain.Orders;

public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository) => _repository = repository;

    public async Task<Order> PlaceOrderAsync(Guid customerId, List<(string product, int qty, decimal price)> items, CancellationToken ct = default)
    {
        var order = Order.Create(customerId);
        foreach (var (product, qty, price) in items)
            order.AddLine(product, qty, price);
        order.Submit();
        await _repository.AddAsync(order, ct);
        return order;
    }
}
