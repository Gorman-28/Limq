using Limq.Core.Domain.Messages.Models;
using MediatR;

namespace Limq.Core.Domain.Messages.Common;
public interface IMessageChatRepository
{
    Task<Unit> Add(MessageChat messageChat);

    Task<MessageChat> Find(Guid userFromId, Guid userToId, DateTimeOffset time);

    Task<Unit> Remove(Guid userFromId, Guid userToId, DateTimeOffset time);

    Task<Unit> RemoveRange(Guid userFromId, Guid userToId);

    Task<Unit> RemoveRangeFromUser(Guid userFromId);
}
