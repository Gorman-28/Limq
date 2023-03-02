using MediatR;

namespace Limq.Application.Domain.MessagesSquad.Command.ChangeMessageSquad;
public record ChangeMessageSquadCommand(Guid SquadId, Guid UserFromId, string Message, DateTime Time, DateTime NewTime) : IRequest<Unit>;
