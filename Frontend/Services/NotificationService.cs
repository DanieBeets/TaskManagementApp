using Microsoft.AspNetCore.SignalR.Client;

namespace Frontend.Services
{
    public class NotificationService
    {
        private readonly HubConnection _hubConnection;

        public event Action<string>? OnNotificationReceived;

        public NotificationService()
        {
            // TODO - use correct url
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://your-server-url/notificationHub")
                .Build();

            _hubConnection.On<string>("ReceiveNotification", (message) =>
            {
                OnNotificationReceived?.Invoke(message);
            });
        }

        public async Task StartAsync()
        {
            await _hubConnection.StartAsync();
        }

        public async Task SendNotificationAsync(string message)
        {
            await _hubConnection.SendAsync("SendNotification", message);
        }
    }
}
