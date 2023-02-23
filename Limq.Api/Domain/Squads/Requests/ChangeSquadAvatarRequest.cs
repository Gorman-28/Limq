namespace Limq.Api.Domain.Squads.Requests;
public record ChangeSquadAvatarRequest(Guid Id, IFormFile NewAvatar);
