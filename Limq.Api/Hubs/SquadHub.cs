using Limq.Application.Domain.UsersSquad.Queries.GetUsersSquad;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Limq.Api.Hubs;

public class SquadHub : Hub
{
    private readonly IMediator _mediator;

    public SquadHub(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task JoinGroup(string squad)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"{squad}");

    }

    public async Task SendMessageToSquad(string myId, string id, string message, string time)
    {
        var query = new GetUsersSquadQuery(Guid.Parse(id));
        var users = await _mediator.Send(query, CancellationToken.None);
        var user = users.FirstOrDefault(u => u.Id == Guid.Parse(myId));
        await Clients.Group($"{id}").SendAsync("SendMessage", user.UserName.ToString(), Convert.ToBase64String(user.Avatar), message, DateTime.Parse(time).ToLocalTime().ToShortTimeString().ToString());
    }

    public async Task SendInSquad(string id, string message, string time)
    {
        await Clients.Group($"{id}").SendAsync("ReceiveMessage", id, message, DateTime.Parse(time).ToLocalTime().ToShortTimeString().ToString());
    }
}
