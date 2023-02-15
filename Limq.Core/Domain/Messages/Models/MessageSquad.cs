namespace Limq.Core.Domain.Messages.Models;
public class MessageSquad
{
    private MessageSquad()
    {
    }

    private MessageSquad(Guid id, Guid squadId, Guid userFromId, string message, DateTimeOffset messageTime)
    {
        Id = id;
        SquadId = squadId;
        UserFromId = userFromId;
        Message = message;
        MessageTime = messageTime;
    }

    public Guid Id { get; private set; }

    public Guid SquadId { get; private set; }

    public Guid UserFromId { get; private set; }

    public string Message { get; private set; }

    public DateTimeOffset MessageTime { get; private set; }

    public static MessageSquad Create(Guid squadId, Guid userFromId, string message, DateTimeOffset messageTime)
    {
        return new MessageSquad(Guid.NewGuid(), squadId, userFromId, message, messageTime);
    }
}
