namespace VariantTestbed.Domain.Compliance;

public class AuditService
{
    private readonly IAuditRepository _repository;

    public AuditService(IAuditRepository repository) => _repository = repository;

    public async Task RecordAsync(string action, string userId, string entityType, string entityId, string? details = null, CancellationToken ct = default)
    {
        var entry = AuditEntry.Create(action, userId, entityType, entityId, details);
        await _repository.SaveAsync(entry, ct);
    }

    public Task<IReadOnlyList<AuditEntry>> GetAuditTrailAsync(string entityType, string entityId, CancellationToken ct = default)
    {
        return _repository.GetByEntityAsync(entityType, entityId, ct);
    }
}
