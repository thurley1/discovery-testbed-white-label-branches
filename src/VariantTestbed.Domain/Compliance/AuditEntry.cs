namespace VariantTestbed.Domain.Compliance;

public class AuditEntry
{
    public Guid Id { get; private set; }
    public string Action { get; private set; } = string.Empty;
    public string UserId { get; private set; } = string.Empty;
    public string EntityType { get; private set; } = string.Empty;
    public string EntityId { get; private set; } = string.Empty;
    public DateTime Timestamp { get; private set; }
    public string? Details { get; private set; }

    public static AuditEntry Create(string action, string userId, string entityType, string entityId, string? details = null)
    {
        return new AuditEntry
        {
            Id = Guid.NewGuid(),
            Action = action,
            UserId = userId,
            EntityType = entityType,
            EntityId = entityId,
            Timestamp = DateTime.UtcNow,
            Details = details
        };
    }
}
