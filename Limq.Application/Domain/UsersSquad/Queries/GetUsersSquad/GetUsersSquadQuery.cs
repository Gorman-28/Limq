using MediatR;

namespace Limq.Application.Domain.UsersSquad.Queries.GetUsersSquad;
public record GetUsersSquadQuery(Guid SquadId) : IRequest<GetUsersSquadDto[]>;
