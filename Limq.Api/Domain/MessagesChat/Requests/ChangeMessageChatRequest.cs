namespace Limq.Api.Domain.MessagesChat.Requests;

public record ChangeMessageChatRequest(Guid UserFromId, Guid UserToId, string Message, DateTime Time, DateTime NewTime);
