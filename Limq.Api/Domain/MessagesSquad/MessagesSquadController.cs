using Limq.Api.Common;
using Limq.Api.Domain.MessagesSquad.Requests;
using Limq.Application.Domain.MessagesSquad.Command.ChangeMessageSquad;
using Limq.Application.Domain.MessagesSquad.Command.CreateMessageSquad;
using Limq.Application.Domain.MessagesSquad.Command.RemoveMessageSquad;
using Limq.Application.Domain.MessagesSquad.Queries.GetMessagesSquad;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Limq.Api.Domain.MessagesSquad;

[ApiController]
[Route(Routes.MessagesSquad)]
public class MessagesSquadController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessagesSquadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("GetMessagesSquad")]

    public async Task<GetMessagesSquadDto[]> GetMessagesSquads([FromQuery] Guid squadId, CancellationToken cancellationToken)
    {
        var query = new GetMessagesSquadQuery(squadId);
        var messagesSquads = await _mediator.Send(query, cancellationToken);
        return messagesSquads;
    }

    [HttpPut]
    [Route("ChangeMessageSquad")]

    public async Task<Unit> ChangeMessageSquad([FromBody] ChangeMessageSquadRequest request, CancellationToken cancellationToken)
    {
        var command = new ChangeMessageSquadCommand(request.SquadId, request.UserFromId, request.Message, request.Time, request.NewTime);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpPost]
    [Route("CreateMessageSquad")]

    public async Task<Unit> CreateMessageSquad([FromBody] CreateMessageSquadRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateMessageSquadCommand(request.SquadId, request.UserFromId, request.Message, request.MessageTime, request.SystemMessage);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpDelete]
    [Route("RemoveMessageSquad")]

    public async Task<Unit> RemoveMessageSquad([FromBody] RemoveMessageSquadRequest request, CancellationToken cancellationToken)
    {
        var command = new RemoveMessageSquadCommand(request.SquadId, request.UserFromId, request.Time);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }
}
