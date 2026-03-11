namespace VariantTestbed.Domain.Loyalty;

public class LoyaltyAccount
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public int PointsBalance { get; private set; }
    public int LifetimePoints { get; private set; }
    public DateTime EnrolledAt { get; private set; }

    public static LoyaltyAccount Enroll(Guid customerId)
    {
        return new LoyaltyAccount
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            PointsBalance = 0,
            LifetimePoints = 0,
            EnrolledAt = DateTime.UtcNow
        };
    }

    public void EarnPoints(int points)
    {
        if (points <= 0) throw new InvalidOperationException("Points must be positive.");
        PointsBalance += points;
        LifetimePoints += points;
    }

    public void RedeemPoints(int points)
    {
        if (points > PointsBalance) throw new InvalidOperationException("Insufficient points.");
        PointsBalance -= points;
    }
}
