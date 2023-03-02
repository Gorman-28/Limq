using MediatR;

namespace Limq.Application.Domain.MessagesChat.Command.RemoveMessageChat;
public record RemoveMessageChatCommand(Guid UserFromId, Guid UserToId, DateTime Time) : IRequest<Unit>;
