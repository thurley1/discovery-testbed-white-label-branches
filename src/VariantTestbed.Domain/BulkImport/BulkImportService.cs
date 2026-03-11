namespace VariantTestbed.Domain.BulkImport;

public class BulkImportService
{
    private readonly ICsvParser _parser;

    public BulkImportService(ICsvParser parser) => _parser = parser;

    public async Task<ImportJob> ImportProductsAsync(string fileName, Stream csvStream, CancellationToken ct = default)
    {
        var rows = await _parser.ParseAsync(csvStream, ct);
        var job = ImportJob.Create(fileName, rows.Count);
        job.Start();

        foreach (var (row, index) in rows.Select((r, i) => (r, i)))
        {
            try
            {
                ValidateRow(row);
                job.RecordProgress(index + 1);
            }
            catch (Exception ex)
            {
                job.RecordError(index + 1, ex.Message);
            }
        }

        job.Complete();
        return job;
    }

    private static void ValidateRow(Dictionary<string, string> row)
    {
        if (!row.ContainsKey("Name") || string.IsNullOrWhiteSpace(row["Name"]))
            throw new InvalidOperationException("Missing product name");
        if (!row.ContainsKey("SKU") || string.IsNullOrWhiteSpace(row["SKU"]))
            throw new InvalidOperationException("Missing SKU");
    }
}
