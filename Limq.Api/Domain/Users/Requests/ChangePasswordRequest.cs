namespace Limq.Api.Domain.Users.Requests;

public record ChangePasswordRequest(Guid Id, string NewPassword);
