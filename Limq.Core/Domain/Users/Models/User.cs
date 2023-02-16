
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

    public string UserName { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
    public List<byte> Avatar { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

    public bool Status { get; set; }

    public ICollection<UserSquad> UserGroups { get; private set; }

    public static User Create(string userName, string password, string firstName, string lastName, List<byte> avatar)
    {
        return new User(Guid.NewGuid(), userName, password, firstName, lastName, avatar);
    }
}
