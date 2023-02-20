using Limq.Core.Domain.Squads.Models;

namespace Limq.Core.Domain.Users.Models;
public class UserSquadBlocked
{
    private UserSquadBlocked()
    {
    }

    private UserSquadBlocked(Guid id, Guid userId, Guid squadId)
    {
        Id = id;
        UserId = userId;
        SquadId = squadId;
    }

    public Guid Id { get; private set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid SquadId { get; set; }
    public Squad Squad { get; set; }

    public static UserSquadBlocked Create(Guid userId, Guid squadId)
    {
        return new UserSquadBlocked(Guid.NewGuid(), userId, squadId);
    }
}
