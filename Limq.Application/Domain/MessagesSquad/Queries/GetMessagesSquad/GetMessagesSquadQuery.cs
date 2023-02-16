using MediatR;

namespace Limq.Application.Domain.MessagesSquad.Queries.GetMessagesSquad;
public record GetMessagesSquadQuery(Guid SquadId) : IRequest<GetMessagesSquadDto[]>;

