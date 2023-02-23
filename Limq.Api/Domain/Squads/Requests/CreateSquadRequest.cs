namespace Limq.Api.Domain.Squads.Requests;

public record CreateSquadRequest(string Name, IFormFile Avatar, Guid AdminId);

