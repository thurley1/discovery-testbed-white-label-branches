namespace VariantTestbed.Domain.Catalog;

public class CatalogService
{
    private readonly IProductRepository _repository;

    public CatalogService(IProductRepository repository) => _repository = repository;

    public async Task<Product> RegisterProductAsync(string name, string sku, decimal price, string category, CancellationToken ct = default)
    {
        var existing = await _repository.GetBySkuAsync(sku, ct);
        if (existing is not null)
            throw new InvalidOperationException($"Product with SKU {sku} already exists.");

        var product = Product.Create(name, sku, price, category);
        await _repository.AddAsync(product, ct);
        return product;
    }
}
