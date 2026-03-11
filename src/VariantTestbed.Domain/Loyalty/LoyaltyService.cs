namespace VariantTestbed.Domain.Loyalty;

public class LoyaltyService
{
    private readonly ILoyaltyRepository _repository;
    private readonly PointsCalculator _calculator;

    public LoyaltyService(ILoyaltyRepository repository, PointsCalculator calculator)
    {
        _repository = repository;
        _calculator = calculator;
    }

    public async Task<LoyaltyAccount> EnrollCustomerAsync(Guid customerId, CancellationToken ct = default)
    {
        var existing = await _repository.GetByCustomerIdAsync(customerId, ct);
        if (existing is not null)
            throw new InvalidOperationException("Customer is already enrolled.");

        var account = LoyaltyAccount.Enroll(customerId);
        await _repository.AddAsync(account, ct);
        return account;
    }

    public async Task EarnPointsForOrderAsync(Guid customerId, decimal orderTotal, CancellationToken ct = default)
    {
        var account = await _repository.GetByCustomerIdAsync(customerId, ct)
            ?? throw new InvalidOperationException("Customer is not enrolled.");

        var points = _calculator.CalculateEarnedPoints(orderTotal);
        account.EarnPoints(points);
        await _repository.SaveAsync(account, ct);
    }

    public async Task<decimal> RedeemPointsAsync(Guid customerId, int points, CancellationToken ct = default)
    {
        var account = await _repository.GetByCustomerIdAsync(customerId, ct)
            ?? throw new InvalidOperationException("Customer is not enrolled.");

        account.RedeemPoints(points);
        await _repository.SaveAsync(account, ct);
        return _calculator.CalculateRedemptionDiscount(points);
    }
}
