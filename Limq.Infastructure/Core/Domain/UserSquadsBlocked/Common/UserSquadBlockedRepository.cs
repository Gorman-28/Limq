using Limq.Core.Domain.Users.Common;
using Limq.Core.Domain.Users.Models;
using Limq.Persistence.LimqDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Limq.Infastructure.Core.Domain.UserSquadsBlocked.Common;
public class UserSquadBlockedRepository : IUserSquadBlockedRepository
{
    private readonly LimqDbContext _limqDbContext;

    public UserSquadBlockedRepository(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }

    public async Task<Unit> Add(UserSquadBlocked userSquadBlocked)
    {
        await _limqDbContext.UserSquadsBlocked.AddAsync(userSquadBlocked);
        return Unit.Value;
    }

    public async Task<Unit> Remove(Guid userId, Guid squadId)
    {
        var userSquadsBlocked = await _limqDbContext.UserSquadsBlocked.FirstOrDefaultAsync(usb => usb.UserId == userId && usb.SquadId == squadId);
        _limqDbContext.UserSquadsBlocked.Remove(userSquadsBlocked);
        return Unit.Value;
    }

    public async Task<Unit> RemoveRange(Guid userId)
    {
        var userSquadBlocked = await _limqDbContext.UserSquadsBlocked.Where(usb => usb.UserId == userId).ToListAsync();
        _limqDbContext.UserSquadsBlocked.RemoveRange(userSquadBlocked);
        return Unit.Value;
    }
}
