namespace VariantTestbed.Domain.Reporting;

public interface IReportGenerator
{
    Task<byte[]> GenerateAsync(Report report, CancellationToken ct = default);
}
