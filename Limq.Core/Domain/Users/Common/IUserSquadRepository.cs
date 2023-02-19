using Limq.Core.Domain.Users.Models;
using MediatR;

namespace Limq.Core.Domain.Users.Common;
public interface IUserSquadRepository
{
    Task<Unit> Add(UserSquad userSquad);

    Task<Unit> Remove(Guid userId, Guid squadId);

    Task<Unit> RemoveRange(Guid userId);
}
