namespace VariantTestbed.Domain.Orders;

public class AcmeDiscountCalculator
{
    public decimal CalculateDiscount(Order order)
    {
        if (order.Total > 1000) return order.Total * 0.15m;
        if (order.Total > 500) return order.Total * 0.10m;
        if (order.Lines.Count > 5) return order.Total * 0.05m;
        return 0;
    }
}
