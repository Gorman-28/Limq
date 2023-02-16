using MediatR;

namespace Limq.Application.Domain.UsersSquad.Command.RemoveUserSquad;
public record RemoveUserSquadCommand(Guid UserId, Guid SquadId) : IRequest<Unit>;

