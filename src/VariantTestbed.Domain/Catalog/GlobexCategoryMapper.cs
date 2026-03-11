namespace VariantTestbed.Domain.Catalog;

public class GlobexCategoryMapper
{
    private static readonly Dictionary<string, string> GlobexMappings = new()
    {
        ["electronics"] = "GLOB-ELEC",
        ["clothing"] = "GLOB-APPAREL",
        ["food"] = "GLOB-CONSUMABLE",
        ["tools"] = "GLOB-INDUSTRIAL"
    };

    public string MapToGlobexCategory(string standardCategory)
    {
        return GlobexMappings.TryGetValue(standardCategory.ToLowerInvariant(), out var mapped)
            ? mapped
            : $"GLOB-{standardCategory.ToUpperInvariant()}";
    }
}
