
using MediatR;

namespace Limq.Application.Domain.MessagesChat.Command.CreateMessageChat;
public record CreateMessageChatCommand(Guid UserFromId, Guid UserToId, string Message, DateTime MessageTime) : IRequest<Unit>;
