namespace Limq.Api.Domain.Squads.Requests;

public record ChangeSquadNameRequest(Guid Id, string NewName);
