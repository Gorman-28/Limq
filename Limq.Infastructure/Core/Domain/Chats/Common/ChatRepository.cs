using Limq.Core.Domain.Chats.Common;
using Limq.Core.Domain.Chats.Models;
using Limq.Persistence.LimqDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Limq.Infastructure.Core.Domain.Chats.Common;
public class ChatRepository : IChatRepository
{
    private readonly LimqDbContext _limqDbContext;

    public ChatRepository(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }
    public async Task<Unit> Add(Chat chat)
    {
        await _limqDbContext.Chats.AddAsync(chat);
        return Unit.Value;
    }

    public async Task<Unit> Remove(Guid firstUserId, Guid secondUserId)
    {
        var chat = await _limqDbContext.Chats.FirstOrDefaultAsync(c => c.FirstUser == firstUserId && c.SecondUser == secondUserId);
        _limqDbContext.Chats.Remove(chat);
        return Unit.Value;
    }

    public async Task<Unit> RemoveRange(Guid id)
    {
        var chat = await _limqDbContext.Chats.Where(c => c.FirstUser == id).ToListAsync();
        _limqDbContext.Chats.RemoveRange(chat);
        return Unit.Value;
    }
}
