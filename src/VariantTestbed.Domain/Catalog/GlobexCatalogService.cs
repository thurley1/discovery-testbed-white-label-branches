namespace VariantTestbed.Domain.Catalog;

public class GlobexCatalogService : CatalogService
{
    private readonly GlobexCategoryMapper _categoryMapper;

    public GlobexCatalogService(IProductRepository repository, GlobexCategoryMapper categoryMapper)
        : base(repository)
    {
        _categoryMapper = categoryMapper;
    }

    public string GetGlobexCategory(Product product) => _categoryMapper.MapToGlobexCategory(product.Category);
}
