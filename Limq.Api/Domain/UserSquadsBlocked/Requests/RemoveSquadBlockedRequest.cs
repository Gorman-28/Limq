namespace Limq.Api.Domain.UserSquadsBlocked.Requests;

public record RemoveSquadBlockedRequest(Guid UserId, Guid SquadId);
