
namespace Limq.Core.Domain.Users.Models;

public class User
{
    private User(Guid id, string userName, string password, string firstName, string lastName, byte[] avatar)
    {
        Id = id;
        UserName = userName;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Avatar = avatar;
        Status = true;
        Theme = true;
    }

    private User()
    {
    }

    public Guid Id { get; private set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
#pragma warning disable CA1819 // Properties should not return arrays
    public byte[] Avatar { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays

    public bool Status { get; set; }

    public bool Theme { get; set; }

    public ICollection<UserSquad> UserSquads { get; private set; }

    public ICollection<UserChatBlocked> UserChatsBlocked1 { get; private set; }

    public ICollection<UserChatBlocked> UserChatsBlocked2 { get; private set; }

    public ICollection<UserSquadBlocked> UserSquadsBlocked { get; private set; }

    public static User Create(string userName, string password, string firstName, string lastName, byte[] avatar)
    {
        return new User(Guid.NewGuid(), userName, password, firstName, lastName, avatar);
    }
}
