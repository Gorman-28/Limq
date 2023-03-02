namespace Limq.Api.Domain.MessagesChat.Requests;

public record CreateMessageChatRequest(Guid UserFromId, Guid UserToId, string Message, DateTime MessageTime);
