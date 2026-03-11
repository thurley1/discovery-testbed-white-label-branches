namespace VariantTestbed.Domain.Auth;

public class AuthenticationService
{
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IUserRepository userRepository) => _userRepository = userRepository;

    public async Task<User> AuthenticateAsync(string email, string password, CancellationToken ct = default)
    {
        var user = await _userRepository.GetByEmailAsync(email, ct)
            ?? throw new UnauthorizedAccessException("Invalid credentials.");

        if (user.IsLocked)
            throw new UnauthorizedAccessException("Account is locked.");

        // Simplified: real implementation would hash and compare
        if (user.PasswordHash != password)
        {
            user.RecordFailedLogin();
            throw new UnauthorizedAccessException("Invalid credentials.");
        }

        user.ResetFailedLogins();
        return user;
    }
}
