using Limq.Api.Common;
using Limq.Api.Domain.UserChatsBlocked.Requests;
using Limq.Application.Domain.UserChatsBlocked.Command.CreateUserChatBlocked;
using Limq.Application.Domain.UserChatsBlocked.Command.RemoveUserChatBlocked;
using Limq.Application.Domain.UserChatsBlocked.Queries.GetChatsBlocked;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Limq.Api.Domain.UserChatsBlocked;

[ApiController]
[Route(Routes.UserChatsBlocked)]
public class UserChatsBlockedController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserChatsBlockedController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]
    [Route("GetUserChatBlocked")]

    public async Task<GetChatsBlockedDto[]> GetChatsBlocked([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        var query = new GetChatsBlockedQuery(id);
        var chatsBlocked = await _mediator.Send(query, cancellationToken);
        return chatsBlocked;
    }

    [HttpPost()]
    [Route("CreateUserChatBlocked")]

    public async Task<Unit> CreateChatBlocked([FromBody] CreateUserBlockedRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateUserChatBlockedCommand(request.FirstUserId, request.SecondUserId);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpDelete()]
    [Route("DeleteUserChatBlocked")]

    public async Task<Unit> RemoveChatBlocked([FromBody] RemoveChatBlockedRequest request, CancellationToken cancellationToken)
    {
        var command = new RemoveUserChatBlockedCommand(request.FirstUserId, request.SecondUserId);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }
}
