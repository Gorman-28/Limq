
namespace Limq.Core.Domain.Users.Models;

public class User
{
    private User(Guid id, string userName, string password, string firstName, string lastName, List<byte> avatar)
    {
        Id = id;
        UserName = userName;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Avatar = avatar;
        Status = true;
    }

    private User()
    {
    }

    public Guid Id { get; private set; }

    public string UserName { get; private set; }

    public string Password { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public List<byte> Avatar { get; private set; }

    public bool Status { get; private set; }

    public ICollection<UserSquad> UserGroups { get; private set; }

    public static User Create(string userName, string password, string firstName, string lastName, List<byte> avatar)
    {
        return new User(Guid.NewGuid(), userName, password, firstName, lastName, avatar);
    }
}
