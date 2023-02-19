using Limq.Api.Common;
using Limq.Api.Domain.Squads.Requests;
using Limq.Application.Domain.Squads.Command.ChangeSquad;
using Limq.Application.Domain.Squads.Command.CreateSquad;
using Limq.Application.Domain.Squads.Command.RemoveSquad;
using Limq.Application.Domain.Squads.Queries.GetSquads;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Limq.Api.Domain.Squads;

[ApiController]
[Route(Routes.Squads)]
public class SquadsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SquadsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]

    public async Task<GetSquadsDto[]> GetSquads(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetSquadsQuery(id);
        var squads = await _mediator.Send(query, cancellationToken);
        return squads;
    }

    [HttpPut]
    [Route("ChangeSquadName")]

    public async Task<Unit> ChangeSquadName([FromBody] ChangeSquadNameRequest request, CancellationToken cancellationToken)
    {
        var command = new ChangeSquadNameCommand(request.Id, request.NewName);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpPut]
    [Route("ChangeSquadAdmin")]

    public async Task<Unit> ChangeSquadAdmin([FromBody] ChangeSquadAdminRequest request, CancellationToken cancellationToken)
    {
        var command = new ChangeSquadAdminCommand(request.Id, request.UserId);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpPut]
    [Route("ChangeSquadAvatar")]

    public async Task<Unit> ChangeSquadAvatar([FromBody] ChangeSquadAvatarRequest request, CancellationToken cancellationToken)
    {
        var command = new ChangeSquadAvatarCommand(request.Id, request.NewAvatar);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpPost]

    public async Task<Unit> CreateSquad([FromBody] CreateSquadRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateSquadCommand(request.Name, request.Avatar, request.AdminId);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpDelete]

    public async Task<Unit> RemoveSquad([FromBody] Guid id, CancellationToken cancellationToken)
    {
        var command = new RemoveSquadCommand(id);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }
}
