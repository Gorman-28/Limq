namespace Limq.Core.Domain.Messages.Models;
public class MessageSquad
{
    private MessageSquad()
    {
    }

    private MessageSquad(Guid id, Guid squadId, Guid userFromId, string message, DateTimeOffset messageTime, bool systemMessage)
    {
        Id = id;
        SquadId = squadId;
        UserFromId = userFromId;
        Message = message;
        MessageTime = messageTime;
        SystemMessage = systemMessage;
    }

    public Guid Id { get; private set; }

    public Guid SquadId { get; private set; }

    public Guid UserFromId { get; private set; }

    public string Message { get; set; }

    public DateTimeOffset MessageTime { get; set; }

    public bool SystemMessage { get; set; }

    public static MessageSquad Create(Guid squadId, Guid userFromId, string message, DateTimeOffset messageTime, bool systemMessage)
    {
        return new MessageSquad(Guid.NewGuid(), squadId, userFromId, message, messageTime, systemMessage);
    }
}
