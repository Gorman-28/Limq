namespace Limq.Api.Domain.Users.Requests;

public record ChangeFirstNameRequest(Guid Id, string NewFirstName);
