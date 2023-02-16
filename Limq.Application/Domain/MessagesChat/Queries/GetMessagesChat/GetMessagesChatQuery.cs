using MediatR;

namespace Limq.Application.Domain.MessagesChat.Queries.GetMessagesChat;
public record GetMessagesSquadQuery(Guid UserFromId, Guid UserToId) : IRequest<GetMessagesChatDto[]>;

