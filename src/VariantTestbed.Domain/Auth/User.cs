namespace VariantTestbed.Domain.Auth;

public class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public string Role { get; private set; } = "User";
    public bool IsLocked { get; private set; }
    public int FailedLoginAttempts { get; private set; }

    public static User Create(string email, string passwordHash, string role = "User")
    {
        return new User { Id = Guid.NewGuid(), Email = email, PasswordHash = passwordHash, Role = role };
    }

    public void RecordFailedLogin()
    {
        FailedLoginAttempts++;
        if (FailedLoginAttempts >= 5) IsLocked = true;
    }

    public void ResetFailedLogins() => FailedLoginAttempts = 0;
    public void Unlock() { IsLocked = false; FailedLoginAttempts = 0; }
}
