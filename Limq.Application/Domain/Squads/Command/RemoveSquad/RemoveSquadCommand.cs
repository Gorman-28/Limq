using MediatR;

namespace Limq.Application.Domain.Squads.Command.RemoveSquad;
public record RemoveSquadCommand(Guid Id) : IRequest<Unit>;
