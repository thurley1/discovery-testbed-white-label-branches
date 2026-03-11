namespace VariantTestbed.Domain.Auth;

public interface IMfaProvider
{
    Task<string> GenerateChallengeAsync(User user, CancellationToken ct = default);
    Task<bool> VerifyChallengeAsync(User user, string code, CancellationToken ct = default);
}
