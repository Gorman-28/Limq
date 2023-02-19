namespace Limq.Api.Domain.Users.Requests;

public record ChangeAvatarRequest(Guid Id, List<byte> Avatar);
