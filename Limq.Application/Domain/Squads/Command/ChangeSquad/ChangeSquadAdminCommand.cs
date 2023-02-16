using MediatR;

namespace Limq.Application.Domain.Squads.Command.ChangeSquad;
public record ChangeSquadAdminCommand(Guid Id, Guid UserId) : IRequest<Unit>;

