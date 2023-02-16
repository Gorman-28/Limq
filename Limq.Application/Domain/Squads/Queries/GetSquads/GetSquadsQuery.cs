using MediatR;

namespace Limq.Application.Domain.Squads.Queries.GetSquads;
public record GetSquadsQuery(Guid UserId) : IRequest<GetSquadsDto[]>;
