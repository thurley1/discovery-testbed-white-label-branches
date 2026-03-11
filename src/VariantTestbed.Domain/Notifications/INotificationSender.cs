namespace VariantTestbed.Domain.Notifications;

public interface INotificationSender
{
    Task SendAsync(string recipient, string subject, string body, CancellationToken ct = default);
}
