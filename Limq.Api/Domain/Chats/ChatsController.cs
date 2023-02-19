using Limq.Api.Common;
using Limq.Api.Domain.Chats.Requests;
using Limq.Application.Domain.Chats.Command.CreateChat;
using Limq.Application.Domain.Chats.Command.RemoveChat;
using Limq.Application.Domain.Chats.Queries.GetAllChats;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Limq.Api.Domain.Chats;

[ApiController]
[Route(Routes.Chats)]
public class ChatsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ChatsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]

    public async Task<GetAllChatsDto[]> GetAllChats([FromBody] Guid id, CancellationToken cancellationToken)
    {
        var query = new GetAllChatsQuery(id);
        var chats = await _mediator.Send(query, cancellationToken);
        return chats;
    }

    [HttpPost()]

    public async Task<Unit> CreateChat([FromBody] CreateChatRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateChatCommand(request.FirstUser, request.SecondUser);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpDelete()]

    public async Task<Unit> RemoveChat([FromBody] RemoveChatRequest request, CancellationToken cancellationToken)
    {
        var command = new RemoveChatCommand(request.FirstUser, request.SecondUser);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

}
