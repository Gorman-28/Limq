namespace Limq.Api.Domain.Squads.Requests;

public record CreateSquadRequest(string Name, List<byte> Avatar, Guid AdminId);
