using MediatR;

namespace Limq.Application.Domain.Chats.Queries.GetAllChats;
public record GetAllChatsQuery(Guid Id) : IRequest<GetAllChatsDto[]>;

