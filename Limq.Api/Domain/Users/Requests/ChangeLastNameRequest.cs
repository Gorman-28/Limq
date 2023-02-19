namespace Limq.Api.Domain.Users.Requests;

public record ChangeLastNameRequest(Guid Id, string NewLastName);
