using MediatR;

namespace Limq.Application.Domain.UsersSquad.Command.CreateUserSquad;
public record CreateUserSquadCommand(Guid UserId, Guid SquadId) : IRequest<Unit>;

