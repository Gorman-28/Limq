using MediatR;

namespace Limq.Application.Domain.MessagesSquad.Command.RemoveMessageSquad;
public record RemoveMessageSquadCommand(Guid SquadId, Guid UserFromId, DateTimeOffset Time) : IRequest<Unit>;
