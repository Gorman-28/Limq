using MediatR;

namespace Limq.Application.Domain.MessagesChat.Command.RemoveMessageChat;
public record RemoveMessageChatCommand(Guid UserFromId, Guid UserToId, DateTimeOffset Time) : IRequest<Unit>;
