using MediatR;

namespace Limq.Application.Domain.MessagesChat.Queries.GetMessagesChat;
public record GetMessagesChatQuery(Guid UserFromId, Guid UserToId) : IRequest<GetMessagesChatDto[]>;

