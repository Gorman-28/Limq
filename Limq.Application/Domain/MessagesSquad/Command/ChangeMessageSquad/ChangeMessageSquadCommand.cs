using MediatR;

namespace Limq.Application.Domain.MessagesSquad.Command.ChangeMessageSquad;
public record ChangeMessageSquadCommand(Guid SquadId, Guid UserFromId, string Message, DateTimeOffset Time, DateTimeOffset NewTime) : IRequest<Unit>;
