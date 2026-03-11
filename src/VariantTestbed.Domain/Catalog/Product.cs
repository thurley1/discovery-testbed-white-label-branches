namespace VariantTestbed.Domain.Catalog;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Sku { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public string Category { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }

    public static Product Create(string name, string sku, decimal price, string category)
    {
        return new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Sku = sku,
            Price = price,
            Category = category,
            IsActive = true
        };
    }

    public void Deactivate() => IsActive = false;
    public void UpdatePrice(decimal newPrice) => Price = newPrice;
}
