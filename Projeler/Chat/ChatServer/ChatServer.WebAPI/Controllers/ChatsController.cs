using ChatServer.WebAPI.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatServer.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ChatsController(
    IHubContext<ChatHub> hubContext) : ControllerBase
{
    public static List<Chat> Chats = new();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Chats);
    }

    [HttpPost]
    public async Task<IActionResult> Send(ChatDto request)
    {
        Chat chat = new()
        {
            UserName = request.UserName,
            Message = request.Message,
            Date = DateTime.Now
        };

        Chats.Add(chat);


        await hubContext.Clients.All.SendAsync("Message", chat);
        return NoContent();
    }
}

public sealed record ChatDto(
    string UserName,
    string Message);

public sealed class Chat
{
    public string UserName { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
}