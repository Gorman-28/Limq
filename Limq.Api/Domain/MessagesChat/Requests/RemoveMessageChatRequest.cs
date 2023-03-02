namespace Limq.Api.Domain.MessagesChat.Requests;

public record RemoveMessageChatRequest(Guid UserFromId, Guid UserToId, DateTime Time);
