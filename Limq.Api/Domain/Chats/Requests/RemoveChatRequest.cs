namespace Limq.Api.Domain.Chats.Requests;

public record RemoveChatRequest(Guid FirstUser, Guid SecondUser);
