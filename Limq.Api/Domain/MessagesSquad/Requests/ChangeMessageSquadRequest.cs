namespace Limq.Api.Domain.MessagesSquad.Requests;

public record ChangeMessageSquadRequest(Guid SquadId, Guid UserFromId, string Message, DateTimeOffset Time, DateTimeOffset NewTime);
