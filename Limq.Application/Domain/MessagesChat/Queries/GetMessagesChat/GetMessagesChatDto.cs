namespace Limq.Application.Domain.MessagesChat.Queries.GetMessagesChat;
public record GetMessagesChatDto
{
    public Guid UserFromId { get; set; }

    public string Message { get; set; }

    public DateTimeOffset MessageTime { get; set; }
}
