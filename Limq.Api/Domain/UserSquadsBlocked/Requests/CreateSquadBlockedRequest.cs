namespace Limq.Api.Domain.UserSquadsBlocked.Requests;

public record CreateSquadBlockedRequest(Guid UserId, Guid SquadId);
