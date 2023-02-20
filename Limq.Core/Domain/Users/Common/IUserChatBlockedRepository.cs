using Limq.Core.Domain.Users.Models;
using MediatR;

namespace Limq.Core.Domain.Users.Common;
public interface IUserChatBlockedRepository
{
    Task<Unit> Add(UserChatBlocked userChatBlocked);

    Task<Unit> Remove(Guid firstId, Guid secondId);

    Task<Unit> RemoveRange(Guid userId);
}
