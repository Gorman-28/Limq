namespace Limq.Api.Domain.UserChatsBlocked.Requests;

public record CreateUserBlockedRequest(Guid FirstUserId, Guid SecondUserId);
