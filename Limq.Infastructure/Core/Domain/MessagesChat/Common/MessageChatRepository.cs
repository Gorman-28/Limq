using Limq.Core.Domain.Messages.Common;
using Limq.Core.Domain.Messages.Models;
using Limq.Persistence.LimqDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Limq.Infastructure.Core.Domain.MessagesChat.Common;
public class MessageChatRepository : IMessageChatRepository
{
    private readonly LimqDbContext _limqDbContext;

    public MessageChatRepository(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }
    public async Task<Unit> Add(MessageChat messageChat)
    {
        await _limqDbContext.MessagesChat.AddAsync(messageChat);
        return Unit.Value;
    }

    public async Task<MessageChat> Find(Guid userFromid, Guid userToid, DateTimeOffset time)
    {
        var messageChat = await _limqDbContext.MessagesChat.FirstOrDefaultAsync(mc => mc.UserFromId == userFromid && mc.UserToId == userToid && mc.MessageTime.Equals(time));
        return messageChat;
    }

    public async Task<Unit> Remove(Guid userFromid, Guid userToid, DateTimeOffset time)
    {
        var messageChat = await _limqDbContext.MessagesChat.FirstOrDefaultAsync(mc => mc.UserFromId == userFromid && mc.UserToId == userToid && mc.MessageTime.Equals(time));
        _limqDbContext.MessagesChat.Remove(messageChat);
        return Unit.Value;
    }

    public async Task<Unit> RemoveRange(Guid userFromid, Guid userToid)
    {
        var messageChat = await _limqDbContext.MessagesChat.Where(ms => ms.UserFromId == userFromid && ms.UserToId == ms.UserToId).ToListAsync();
        _limqDbContext.MessagesChat.RemoveRange(messageChat);
        return Unit.Value;
    }
}
