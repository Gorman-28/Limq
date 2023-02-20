using MediatR;

namespace Limq.Application.Domain.UserSquadsBlocked.Queries.GetSquadsBlocked;
public record GetSquadsBlockedQuery(Guid Id) : IRequest<GetSquadsBlockedDto[]>;

