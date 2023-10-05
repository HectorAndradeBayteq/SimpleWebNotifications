using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Notificator.Hubs;

namespace Notificator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificatorController : ControllerBase
    {
        private readonly IHubContext<NotificatorHub> _hubContext;

        public NotificatorController(IHubContext<NotificatorHub> hubContext)
        {
            _hubContext = hubContext;
        }


        [HttpPost]
        public async Task<IActionResult> SendMessage ([FromBody] string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);            
            return Ok();
        }
    }
}
