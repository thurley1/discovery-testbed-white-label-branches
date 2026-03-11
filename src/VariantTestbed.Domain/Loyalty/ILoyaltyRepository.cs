namespace VariantTestbed.Domain.Loyalty;

public interface ILoyaltyRepository
{
    Task<LoyaltyAccount?> GetByCustomerIdAsync(Guid customerId, CancellationToken ct = default);
    Task AddAsync(LoyaltyAccount account, CancellationToken ct = default);
    Task SaveAsync(LoyaltyAccount account, CancellationToken ct = default);
}
