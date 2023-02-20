using Limq.Core.Domain.Squads.Models;

namespace Limq.Core.Domain.Users.Models;
public class UserSquad
{
    private UserSquad()
    {
    }
    private UserSquad(Guid userId, Guid squadId)
    {
        UserId = userId;
        SquadId = squadId;
    }
    public Guid UserId { get; private set; }

    public User User { get; private set; }

    public Guid SquadId { get; private set; }

    public Squad Squad { get; private set; }

    public static UserSquad Create(Guid userId, Guid squadId)
    {
        return new UserSquad(userId, squadId);
    }
}
