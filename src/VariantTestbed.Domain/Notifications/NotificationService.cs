namespace VariantTestbed.Domain.Notifications;

public class NotificationService
{
    private readonly INotificationSender _sender;

    public NotificationService(INotificationSender sender) => _sender = sender;

    public Task SendOrderConfirmationAsync(string email, Guid orderId, CancellationToken ct = default)
    {
        return _sender.SendAsync(email, "Order Confirmed", $"Your order {orderId} has been confirmed.", ct);
    }

    public Task SendPasswordResetAsync(string email, string resetLink, CancellationToken ct = default)
    {
        return _sender.SendAsync(email, "Password Reset", $"Reset your password: {resetLink}", ct);
    }
}
