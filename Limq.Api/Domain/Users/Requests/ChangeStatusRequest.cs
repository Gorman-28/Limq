namespace Limq.Api.Domain.Users.Requests;

public record ChangeStatusRequest(Guid Id, bool Status);
