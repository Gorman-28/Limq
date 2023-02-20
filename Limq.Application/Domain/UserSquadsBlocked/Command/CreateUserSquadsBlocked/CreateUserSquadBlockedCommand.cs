using MediatR;

namespace Limq.Application.Domain.UserSquadsBlocked.Command.CreateUserSquadsBlocked;
public record CreateUserSquadBlockedCommand(Guid UserId, Guid SquadId) : IRequest<Unit>;
