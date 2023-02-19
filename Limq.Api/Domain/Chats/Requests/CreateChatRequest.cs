namespace Limq.Api.Domain.Chats.Requests;

public record CreateChatRequest(Guid FirstUser, Guid SecondUser);
