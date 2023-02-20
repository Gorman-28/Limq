using Limq.Core.Domain.Users.Common;
using Limq.Core.Domain.Users.Models;
using Limq.Persistence.LimqDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Limq.Infastructure.Core.Domain.UserChatsBlocked.Common;
public class UserChatBlockedRepository : IUserChatBlockedRepository
{
    private readonly LimqDbContext _limqDbContext;

    public UserChatBlockedRepository(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }
    public async Task<Unit> Add(UserChatBlocked userChatBlocked)
    {
        await _limqDbContext.UserChatsBlocked.AddAsync(userChatBlocked);
        return Unit.Value;
    }

    public async Task<Unit> Remove(Guid firstId, Guid secondId)
    {
        var userChatBlocked = await _limqDbContext.UserChatsBlocked.FirstOrDefaultAsync(ucb => ucb.FirstUser == firstId && ucb.SecondUser == secondId);
        _limqDbContext.UserChatsBlocked.Remove(userChatBlocked);
        return Unit.Value;
    }

    public async Task<Unit> RemoveRange(Guid userId)
    {
        var userChatBlocked = await _limqDbContext.UserChatsBlocked.Where(ucb => ucb.FirstUser == userId).ToListAsync();
        _limqDbContext.UserChatsBlocked.RemoveRange(userChatBlocked);
        return Unit.Value;
    }
}
