namespace VariantTestbed.Domain.Orders;

public class AcmeOrderService : OrderService
{
    private readonly AcmeDiscountCalculator _discountCalculator;

    public AcmeOrderService(IOrderRepository repository, AcmeDiscountCalculator discountCalculator)
        : base(repository)
    {
        _discountCalculator = discountCalculator;
    }

    public decimal GetDiscountedTotal(Order order)
    {
        var discount = _discountCalculator.CalculateDiscount(order);
        return order.Total - discount;
    }
}
