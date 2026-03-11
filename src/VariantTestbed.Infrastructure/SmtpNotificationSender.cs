using VariantTestbed.Domain.Notifications;

namespace VariantTestbed.Infrastructure.Email;

public class SmtpNotificationSender : INotificationSender
{
    public Task SendAsync(string recipient, string subject, string body, CancellationToken ct = default)
    {
        Console.WriteLine($"[EMAIL] To: {recipient}, Subject: {subject}");
        return Task.CompletedTask;
    }
}
