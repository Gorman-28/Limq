using Limq.Api.Common;
using Limq.Api.Domain.UsersSquad.Requests;
using Limq.Application.Domain.UsersSquad.Command.CreateUserSquad;
using Limq.Application.Domain.UsersSquad.Command.RemoveUserSquad;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Limq.Api.Domain.UsersSquad;

[ApiController]
[Route(Routes.UsersSquad)]
public class UsersSquadController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersSquadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]

    public async Task<Unit> CreateUserSquad([FromBody] CreateUserSquadRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateUserSquadCommand(request.UserId, request.SquadId);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpDelete]

    public async Task<Unit> RemoveUserSquad([FromBody] RemoveUserSquadRequest request, CancellationToken cancellationToken)
    {
        var command = new RemoveUserSquadCommand(request.UserId, request.SquadId);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }
}
