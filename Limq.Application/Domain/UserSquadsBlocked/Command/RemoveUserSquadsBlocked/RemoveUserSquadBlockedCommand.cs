using MediatR;

namespace Limq.Application.Domain.UserSquadsBlocked.Command.RemoveUserSquadsBlocked;
public record RemoveUserSquadBlockedCommand(Guid UserId, Guid SquadId) : IRequest<Unit>;

