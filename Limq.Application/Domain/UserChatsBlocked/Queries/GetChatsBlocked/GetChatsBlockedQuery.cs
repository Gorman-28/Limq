using MediatR;

namespace Limq.Application.Domain.UserChatsBlocked.Queries.GetChatsBlocked;
public record GetChatsBlockedQuery(Guid Id) : IRequest<GetChatsBlockedDto[]>;
