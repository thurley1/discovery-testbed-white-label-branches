namespace VariantTestbed.Domain.Reporting;

public class ReportService
{
    private readonly IReportGenerator _generator;

    public ReportService(IReportGenerator generator) => _generator = generator;

    public async Task<Report> GenerateSalesReportAsync(string name, CancellationToken ct = default)
    {
        var report = Report.Create(name, ReportType.Sales);
        await _generator.GenerateAsync(report, ct);
        return report;
    }

    public async Task<Report> GenerateInventoryReportAsync(string name, CancellationToken ct = default)
    {
        var report = Report.Create(name, ReportType.Inventory);
        await _generator.GenerateAsync(report, ct);
        return report;
    }
}
