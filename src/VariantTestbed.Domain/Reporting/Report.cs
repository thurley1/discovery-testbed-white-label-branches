namespace VariantTestbed.Domain.Reporting;

public class Report
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public ReportType Type { get; private set; }
    public DateTime GeneratedAt { get; private set; }
    public string OutputFormat { get; private set; } = "PDF";

    public static Report Create(string name, ReportType type, string format = "PDF")
    {
        return new Report
        {
            Id = Guid.NewGuid(),
            Name = name,
            Type = type,
            GeneratedAt = DateTime.UtcNow,
            OutputFormat = format
        };
    }
}
