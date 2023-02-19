namespace Limq.Api.Domain.MessagesChat.Requests;

public record GetMessagesChatRequest(Guid UserFromId, Guid UserToId);
