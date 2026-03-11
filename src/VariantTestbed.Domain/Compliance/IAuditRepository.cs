namespace VariantTestbed.Domain.Compliance;

public interface IAuditRepository
{
    Task SaveAsync(AuditEntry entry, CancellationToken ct = default);
    Task<IReadOnlyList<AuditEntry>> GetByEntityAsync(string entityType, string entityId, CancellationToken ct = default);
    Task<IReadOnlyList<AuditEntry>> GetByUserAsync(string userId, DateTime from, DateTime to, CancellationToken ct = default);
}
