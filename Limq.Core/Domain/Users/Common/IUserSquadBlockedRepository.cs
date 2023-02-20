using Limq.Core.Domain.Users.Models;
using MediatR;

namespace Limq.Core.Domain.Users.Common;
public interface IUserSquadBlockedRepository
{
    Task<Unit> Add(UserSquadBlocked userSquadBlocked);

    Task<Unit> Remove(Guid userId, Guid squadId);

    Task<Unit> RemoveRange(Guid userId);
}
