namespace VariantTestbed.Domain.Orders;

public record OrderLine(string ProductName, int Quantity, decimal UnitPrice);
