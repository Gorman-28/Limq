using Limq.Core.Domain.Users.Models;

namespace Limq.Core.Domain.Squads.Models;
public class Squad
{
    private Squad()
    {
    }

    private Squad(Guid id, string name, List<byte> avatar, Guid adminId)
    {
        Id = id;
        Name = name;
        Avatar = avatar;
        AdminId = adminId;
    }
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public List<byte> Avatar { get; private set; }

    public Guid AdminId { get; private set; }

    public ICollection<UserSquad> UserGroups { get; private set; }

    public static Squad Create(string name, List<byte> avatar, Guid adminId)
    {
        return new Squad(Guid.NewGuid(), name, avatar, adminId);
    }
}
