using MediatR;

namespace Limq.Application.Domain.MessagesChat.Command.ChangeMessageChat;
public record ChangeMessageChatCommand(Guid UserFromId, Guid UserToId, string Message, DateTime Time, DateTime NewTime) : IRequest<Unit>;
