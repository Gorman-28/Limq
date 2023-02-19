namespace Limq.Api.Domain.MessagesChat.Requests;

public record ChangeMessageChatRequest(Guid UserFromId, Guid UserToId, string Message, DateTimeOffset Time, DateTimeOffset NewTime);
