using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;

namespace Limq.Api.Hubs;


[Route("/ChatHub")]
public class ChatHub : Hub
{

    public async Task JoinGroup(string chat, string myId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"{myId}{chat}");

    }

    public async Task SendMessageToGroup(string myId, string id, string message, string time)
    {
        await Clients.Group($"{id}{myId}").SendAsync("SendMessage", id, message, DateTime.Parse(time).ToLocalTime().ToShortTimeString().ToString());
    }

    public async Task SendInChat(string myId, string id, string message, string time)
    {
        await Clients.Group($"{id}{myId}").SendAsync("ReceiveMessage", myId, message, DateTime.Parse(time).ToLocalTime().ToShortTimeString().ToString());
    }
}
