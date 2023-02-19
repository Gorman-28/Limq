namespace Limq.Api.Domain.Squads.Requests;

public record ChangeSquadAvatarRequest(Guid Id, List<byte> NewAvatar);
