namespace VariantTestbed.Domain.BulkImport;

public interface ICsvParser
{
    Task<IReadOnlyList<Dictionary<string, string>>> ParseAsync(Stream csvStream, CancellationToken ct = default);
}
