using Limq.Application.Domain.UsersSquad.Queries.GetUsersSquad;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;

namespace Limq.Api.Hubs;

[Route("/SquadHub")]
public class SquadHub : Hub
{
    private readonly IMediator _mediator;

    public SquadHub(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task JoinGroup(string squad, string myId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"{myId}{squad}");

    }

    public async Task SendMessageToSquad(string myId, string id, string message, string time)
    {
        var query = new GetUsersSquadQuery(Guid.Parse(id));
        var users = await _mediator.Send(query, CancellationToken.None);
        var user = users.FirstOrDefault(u => u.Id == Guid.Parse(myId));
        await Clients.Group($"{id}{myId}").SendAsync("SendMessage", user.UserName.ToString(), Convert.ToBase64String(user.Avatar), message, DateTime.Parse(time).ToLocalTime().ToShortTimeString().ToString());
    }

    public async Task SendInSquad(string myId, string id, string message, string time)
    {
        await Clients.Group($"{id}{myId}").SendAsync("ReceiveMessage", myId, message, DateTime.Parse(time).ToLocalTime().ToShortTimeString().ToString());
    }
}
