namespace Limq.Api.Domain.MessagesSquad.Requests;

public record RemoveMessageSquadRequest(Guid SquadId, Guid UserFromId, DateTime Time);
