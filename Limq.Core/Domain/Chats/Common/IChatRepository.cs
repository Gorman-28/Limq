using Limq.Core.Domain.Chats.Models;
using MediatR;

namespace Limq.Core.Domain.Chats.Common;
public interface IChatRepository
{
    Task<Unit> Add(Chat chat);

    Task<Unit> Remove(Guid firstUserId, Guid secondUserId);

    Task<Unit> RemoveRange(Guid id);
}
