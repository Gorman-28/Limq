using Limq.Core.Domain.Users.Common;
using Limq.Core.Domain.Users.Models;
using Limq.Persistence.LimqDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Limq.Infastructure.Core.Domain.UserSquads.Common;
public class UserSquadRepository : IUserSquadRepository
{
    private readonly LimqDbContext _limqDbContext;

    public UserSquadRepository(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }
    public async Task<Unit> Add(UserSquad userSquad)
    {
        await _limqDbContext.UserSquads.AddAsync(userSquad);
        return Unit.Value;
    }

    public async Task<Unit> Remove(Guid userId, Guid squadId)
    {
        var userSquad = await _limqDbContext.UserSquads.FirstOrDefaultAsync(ug => ug.UserId == userId && ug.SquadId == squadId);
        _limqDbContext.UserSquads.Remove(userSquad);
        return Unit.Value;
    }

    public async Task<Unit> RemoveRange(Guid userId)
    {
        var userSquads = await _limqDbContext.UserSquads.Where(us => us.UserId == userId).ToListAsync();
        _limqDbContext.UserSquads.RemoveRange(userSquads);
        return Unit.Value;
    }

    public async Task<Unit> RemoveRangeSquad(Guid squadId)
    {
        var userSquads = await _limqDbContext.UserSquads.Where(us => us.SquadId == squadId).ToListAsync();
        _limqDbContext.UserSquads.RemoveRange(userSquads);
        return Unit.Value;
    }
}
