namespace VariantTestbed.Domain.Loyalty;

public class TierBenefitsCalculator
{
    public decimal GetDiscountPercentage(MembershipTier tier) => tier switch
    {
        MembershipTier.Platinum => 0.20m,
        MembershipTier.Gold => 0.15m,
        MembershipTier.Silver => 0.10m,
        MembershipTier.Bronze => 0.0m,
        _ => 0.0m
    };

    public bool GetFreeShipping(MembershipTier tier) => tier >= MembershipTier.Gold;
    public bool GetPrioritySupport(MembershipTier tier) => tier >= MembershipTier.Silver;
    public int GetReturnWindowDays(MembershipTier tier) => tier >= MembershipTier.Gold ? 60 : 30;
}
