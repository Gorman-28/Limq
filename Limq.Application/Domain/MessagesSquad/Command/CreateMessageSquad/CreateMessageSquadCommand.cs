
using MediatR;

namespace Limq.Application.Domain.MessagesSquad.Command.CreateMessageSquad;
public record CreateMessageSquadCommand(Guid SquadId, Guid UserFromId, string Message, DateTimeOffset MessageTime) : IRequest<Unit>;
