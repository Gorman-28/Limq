
namespace Limq.Core.Domain.Messages.Models;
public class MessageChat
{
    private MessageChat()
    {
    }

    private MessageChat(Guid id, Guid userFromId, Guid userToId, string message, DateTimeOffset messageTime)
    {
        Id = id;
        UserFromId = userFromId;
        UserToId = userToId;
        Message = message;
        MessageTime = messageTime;
    }

    public Guid Id { get; private set; }

    public Guid UserFromId { get; private set; }

    public Guid UserToId { get; private set; }

    public string Message { get; private set; }

    public DateTimeOffset MessageTime { get; private set; }

    public static MessageChat Create(Guid userFromId, Guid userToId, string message, DateTimeOffset messageTime)
    {
        return new MessageChat(Guid.NewGuid(), userFromId, userToId, message, messageTime);
    }
}
