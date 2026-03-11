namespace VariantTestbed.Domain.Catalog;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<Product?> GetBySkuAsync(string sku, CancellationToken ct = default);
    Task<IReadOnlyList<Product>> SearchAsync(string? category, bool activeOnly, CancellationToken ct = default);
    Task AddAsync(Product product, CancellationToken ct = default);
}
