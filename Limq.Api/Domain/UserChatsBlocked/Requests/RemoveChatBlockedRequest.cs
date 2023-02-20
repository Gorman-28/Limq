namespace Limq.Api.Domain.UserChatsBlocked.Requests;

public record RemoveChatBlockedRequest(Guid FirstUserId, Guid SecondUserId);
