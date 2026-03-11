namespace VariantTestbed.Domain.Loyalty;

public class MemberProfile
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public MembershipTier Tier { get; private set; }
    public decimal LifetimeSpend { get; private set; }
    public DateTime MemberSince { get; private set; }
    public DateTime? TierExpiresAt { get; private set; }

    public static MemberProfile Create(Guid customerId)
    {
        return new MemberProfile
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            Tier = MembershipTier.Bronze,
            LifetimeSpend = 0,
            MemberSince = DateTime.UtcNow,
            TierExpiresAt = DateTime.UtcNow.AddYears(1)
        };
    }

    public void RecordPurchase(decimal amount)
    {
        LifetimeSpend += amount;
        RecalculateTier();
    }

    private void RecalculateTier()
    {
        Tier = LifetimeSpend switch
        {
            >= 10000 => MembershipTier.Platinum,
            >= 5000 => MembershipTier.Gold,
            >= 1000 => MembershipTier.Silver,
            _ => MembershipTier.Bronze
        };
        TierExpiresAt = DateTime.UtcNow.AddYears(1);
    }

    public bool IsTierExpired() => TierExpiresAt.HasValue && TierExpiresAt.Value < DateTime.UtcNow;

    public void DemoteIfExpired()
    {
        if (IsTierExpired() && Tier != MembershipTier.Bronze)
        {
            Tier = (MembershipTier)((int)Tier - 1);
            TierExpiresAt = DateTime.UtcNow.AddYears(1);
        }
    }
}
