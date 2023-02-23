namespace Limq.Api.Domain.Users.Requests;

public record ChangeAvatarRequest(Guid Id, IFormFile Avatar);
