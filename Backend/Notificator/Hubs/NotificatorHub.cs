using Microsoft.AspNetCore.SignalR;

namespace Notificator.Hubs
{
    public class NotificatorHub : Hub
    {
        public async Task SendMessage (string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
