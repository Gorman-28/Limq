namespace Limq.Core.Domain.Users.Models;
public class UserChatBlocked
{
    private UserChatBlocked()
    {
    }

    private UserChatBlocked(Guid id, Guid firstUser, Guid secondUser)
    {
        Id = id;
        FirstUser = firstUser;
        SecondUser = secondUser;
    }

    public Guid Id { get; private set; }
    public Guid FirstUser { get; set; }
    public User User1 { get; set; }

    public Guid SecondUser { get; set; }
    public User User2 { get; set; }

    public static UserChatBlocked Create(Guid firstUser, Guid secondUser)
    {
        return new UserChatBlocked(Guid.NewGuid(), firstUser, secondUser);
    }

}
