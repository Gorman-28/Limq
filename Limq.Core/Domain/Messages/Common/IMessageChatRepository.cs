using Limq.Core.Domain.Messages.Models;
using MediatR;

namespace Limq.Core.Domain.Messages.Common;
public interface IMessageChatRepository
{
    Task<Unit> Add(MessageChat messageChat);

    Task<MessageChat> Find(Guid userFromid, Guid userToid, DateTimeOffset time);

    Task<Unit> Remove(Guid userFromid, Guid userToid, DateTimeOffset time);

    Task<Unit> RemoveRange(Guid userFromid, Guid userToid);
}
