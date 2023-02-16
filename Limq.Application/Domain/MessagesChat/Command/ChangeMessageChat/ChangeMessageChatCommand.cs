using MediatR;

namespace Limq.Application.Domain.MessagesChat.Command.ChangeMessageChat;
public record ChangeMessageSquadCommand(Guid UserFromId, Guid UserToId, string Message, DateTimeOffset Time, DateTimeOffset NewTime) : IRequest<Unit>;
