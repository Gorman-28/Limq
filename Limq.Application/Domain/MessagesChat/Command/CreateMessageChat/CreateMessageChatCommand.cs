
using MediatR;

namespace Limq.Application.Domain.MessagesChat.Command.CreateMessageChat;
public record CreateMessageSquadCommand(Guid UserFromId, Guid UserToId, string Message, DateTimeOffset MessageTime) : IRequest<Unit>;
