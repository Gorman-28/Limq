using Limq.Api.Common;
using Limq.Api.Domain.MessagesChat.Requests;
using Limq.Application.Domain.MessagesChat.Command.ChangeMessageChat;
using Limq.Application.Domain.MessagesChat.Command.CreateMessageChat;
using Limq.Application.Domain.MessagesChat.Command.RemoveMessageChat;
using Limq.Application.Domain.MessagesChat.Queries.GetMessagesChat;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Limq.Api.Domain.MessagesChat;

[ApiController]
[Route(Routes.MessagesChat)]
public class MessagesChatController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessagesChatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]

    public async Task<GetMessagesChatDto[]> GetMessagesChats([FromBody] GetMessagesChatRequest request, CancellationToken cancellationToken)
    {
        var query = new GetMessagesChatQuery(request.UserFromId, request.UserToId);
        var chatMessages = await _mediator.Send(query, cancellationToken);
        return chatMessages;
    }

    [HttpPut]

    public async Task<Unit> ChangeMessageChat([FromBody] ChangeMessageChatRequest request, CancellationToken cancellationToken)
    {
        var command = new ChangeMessageChatCommand(request.UserFromId, request.UserToId, request.Message, request.Time, request.NewTime);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpPost]

    public async Task<Unit> CreateMessageChat([FromBody] CreateMessageChatRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateMessageChatCommand(request.UserFromId, request.UserToId, request.Message, request.MessageTime);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }

    [HttpDelete]

    public async Task<Unit> RemoveMessageChat([FromBody] RemoveMessageChatRequest request, CancellationToken cancellationToken)
    {
        var command = new RemoveMessageChatCommand(request.UserFromId, request.UserToId, request.Time);
        await _mediator.Send(command, cancellationToken);
        return Unit.Value;
    }
}
