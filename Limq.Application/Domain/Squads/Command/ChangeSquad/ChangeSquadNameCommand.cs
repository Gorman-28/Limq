using MediatR;

namespace Limq.Application.Domain.Squads.Command.ChangeSquad;
public record ChangeSquadNameCommand(Guid Id, string NewName) : IRequest<Unit>;

