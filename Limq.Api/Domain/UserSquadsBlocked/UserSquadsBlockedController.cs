using Limq.Api.Domain.UserSquadsBlocked.Requests;
using Limq.Application.Domain.UserSquadsBlocked.Command.CreateUserSquadsBlocked;
using Limq.Application.Domain.UserSquadsBlocked.Command.RemoveUserSquadsBlocked;
using Limq.Application.Domain.UserSquadsBlocked.Queries.GetSquadsBlocked;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Limq.Api.Domain.UserSquadsBlocked;
public class UserSquadsBlockedController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserSquadsBlockedController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]

    public async Task<GetSquadsBlockedDto[]> GetSquadsBlockeds([FromBody] Guid id, CancellationToken cancellationToken)
    {
        var query = new GetSquadsBlockedQuery(id);
        var squadsBlocked = await _mediator.Send(query, cancellationToken);
        return squadsBlocked;
    }

    [HttpPost()]

    public async Task<Unit> CreateSquadBlocked([FromBody] CreateSquadBlockedRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateUserSquadBlockedCommand(request.UserId, request.SquadId);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpDelete()]

    public async Task<Unit> RemoveSquadBlocked([FromBody] RemoveSquadBlockedRequest request, CancellationToken cancellationToken)
    {
        var command = new RemoveUserSquadBlockedCommand(request.UserId, request.SquadId);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }
}
