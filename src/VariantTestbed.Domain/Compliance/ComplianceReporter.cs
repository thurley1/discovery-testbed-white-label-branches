namespace VariantTestbed.Domain.Compliance;

public class ComplianceReporter
{
    private readonly IAuditRepository _repository;

    public ComplianceReporter(IAuditRepository repository) => _repository = repository;

    public async Task<ComplianceReport> GenerateReportAsync(string userId, DateTime from, DateTime to, CancellationToken ct = default)
    {
        var entries = await _repository.GetByUserAsync(userId, from, to, ct);
        return new ComplianceReport(userId, from, to, entries);
    }
}

public record ComplianceReport(string UserId, DateTime From, DateTime To, IReadOnlyList<AuditEntry> Entries)
{
    public int TotalActions => Entries.Count;
    public IReadOnlyList<AuditEntry> SensitiveActions => Entries.Where(e => e.Action.StartsWith("DELETE") || e.Action.StartsWith("EXPORT")).ToList();
}
