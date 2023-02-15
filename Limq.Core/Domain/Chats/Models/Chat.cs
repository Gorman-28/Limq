namespace Limq.Core.Domain.Chats.Models;
public class Chat
{
    private Chat()
    {
    }

    private Chat(Guid id, Guid firstUser, Guid secondUser)
    {
        Id = id;
        FirstUser = firstUser;
        SecondUser = secondUser;
    }
    public Guid Id { get; private set; }

    public Guid FirstUser { get; private set; }

    public Guid SecondUser { get; private set; }

    public static Chat Create(Guid firstUser, Guid secondUser)
    {
        return new Chat(Guid.NewGuid(), firstUser, secondUser);
    }
}
