namespace Limq.Api.Domain.MessagesSquad.Requests;

public record RemoveMessageSquadRequest(Guid SquadId, Guid UserFromId, DateTimeOffset Time);
