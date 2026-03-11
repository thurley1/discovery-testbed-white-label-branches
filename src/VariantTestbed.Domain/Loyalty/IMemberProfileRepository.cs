namespace VariantTestbed.Domain.Loyalty;

public interface IMemberProfileRepository
{
    Task<MemberProfile?> GetByCustomerIdAsync(Guid customerId, CancellationToken ct = default);
    Task AddAsync(MemberProfile profile, CancellationToken ct = default);
    Task SaveAsync(MemberProfile profile, CancellationToken ct = default);
    Task<IReadOnlyList<MemberProfile>> GetByTierAsync(MembershipTier tier, CancellationToken ct = default);
}
