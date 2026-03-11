namespace VariantTestbed.Domain.Loyalty;

public class MembershipService
{
    private readonly IMemberProfileRepository _repository;
    private readonly TierBenefitsCalculator _benefitsCalculator;

    public MembershipService(IMemberProfileRepository repository, TierBenefitsCalculator benefitsCalculator)
    {
        _repository = repository;
        _benefitsCalculator = benefitsCalculator;
    }

    public async Task<MemberProfile> EnrollAsync(Guid customerId, CancellationToken ct = default)
    {
        var existing = await _repository.GetByCustomerIdAsync(customerId, ct);
        if (existing is not null)
            throw new InvalidOperationException("Customer already has a membership.");

        var profile = MemberProfile.Create(customerId);
        await _repository.AddAsync(profile, ct);
        return profile;
    }

    public async Task RecordPurchaseAsync(Guid customerId, decimal amount, CancellationToken ct = default)
    {
        var profile = await _repository.GetByCustomerIdAsync(customerId, ct)
            ?? throw new InvalidOperationException("Customer has no membership.");

        profile.RecordPurchase(amount);
        await _repository.SaveAsync(profile, ct);
    }

    public async Task<decimal> GetOrderDiscountAsync(Guid customerId, decimal orderTotal, CancellationToken ct = default)
    {
        var profile = await _repository.GetByCustomerIdAsync(customerId, ct);
        if (profile is null) return 0;

        var discountPct = _benefitsCalculator.GetDiscountPercentage(profile.Tier);
        return orderTotal * discountPct;
    }
}
