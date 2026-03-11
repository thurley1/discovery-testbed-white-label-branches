namespace VariantTestbed.Domain.Auth;

public class MfaAuthenticationService : AuthenticationService
{
    private readonly IMfaProvider _mfaProvider;

    public MfaAuthenticationService(IUserRepository userRepository, IMfaProvider mfaProvider)
        : base(userRepository)
    {
        _mfaProvider = mfaProvider;
    }

    public async Task<string> InitiateMfaAsync(User user, CancellationToken ct = default)
    {
        return await _mfaProvider.GenerateChallengeAsync(user, ct);
    }

    public async Task<bool> CompleteMfaAsync(User user, string code, CancellationToken ct = default)
    {
        return await _mfaProvider.VerifyChallengeAsync(user, code, ct);
    }
}
