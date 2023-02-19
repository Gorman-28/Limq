namespace Limq.Api.Domain.MessagesSquad.Requests;

public record CreateMessageSquadRequest(Guid SquadId, Guid UserFromId, string Message, DateTimeOffset MessageTime);
