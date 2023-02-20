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

    public string Name { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
    public List<byte> Avatar { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

    public Guid AdminId { get; set; }

    public ICollection<UserSquad> UserSquads { get; private set; }

    public ICollection<UserSquadBlocked> UserSquadsBlocked { get; private set; }

    public static Squad Create(string name, List<byte> avatar, Guid adminId)
    {
        return new Squad(Guid.NewGuid(), name, avatar, adminId);
    }
}
