namespace Limq.Api.Domain.Users.Requests;

public record ChangeUserNameRequest(Guid Id, string NewUserName);
