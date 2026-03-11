namespace VariantTestbed.Domain.BulkImport;

public class ImportJob
{
    public Guid Id { get; private set; }
    public string FileName { get; private set; } = string.Empty;
    public ImportStatus Status { get; private set; }
    public int TotalRows { get; private set; }
    public int ProcessedRows { get; private set; }
    public int ErrorCount { get; private set; }
    public List<ImportError> Errors { get; private set; } = new();

    public static ImportJob Create(string fileName, int totalRows)
    {
        return new ImportJob
        {
            Id = Guid.NewGuid(),
            FileName = fileName,
            TotalRows = totalRows,
            Status = ImportStatus.Queued
        };
    }

    public void Start() => Status = ImportStatus.Running;
    public void RecordProgress(int processed) => ProcessedRows = processed;
    public void RecordError(int row, string message) { ErrorCount++; Errors.Add(new ImportError(row, message)); }
    public void Complete() => Status = ProcessedRows == TotalRows ? ImportStatus.Completed : ImportStatus.CompletedWithErrors;
    public void Fail() => Status = ImportStatus.Failed;
}
