namespace VariantTestbed.Domain.Loyalty;

public class PointsCalculator
{
    private const int PointsPerDollar = 10;
    private const decimal PointRedemptionValue = 0.01m;

    public int CalculateEarnedPoints(decimal orderTotal)
    {
        return (int)Math.Floor(orderTotal) * PointsPerDollar;
    }

    public decimal CalculateRedemptionDiscount(int points)
    {
        return points * PointRedemptionValue;
    }

    public int PointsRequiredForDiscount(decimal discountAmount)
    {
        return (int)Math.Ceiling(discountAmount / PointRedemptionValue);
    }
}
