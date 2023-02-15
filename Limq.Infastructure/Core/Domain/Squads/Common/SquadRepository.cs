using Limq.Core.Domain.Squads.Common;
using Limq.Core.Domain.Squads.Models;
using Limq.Persistence.LimqDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Limq.Infastructure.Core.Domain.Squads.Common;
public class SquadRepository : ISquadRepository
{
    private readonly LimqDbContext _limqDbContext;

    public SquadRepository(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }
    public async Task<Unit> Add(Squad squad)
    {
        await _limqDbContext.Squads.AddAsync(squad);
        return Unit.Value;
    }

    public async Task<Squad> Find(Guid id)
    {
        var squad = await _limqDbContext.Squads.FirstOrDefaultAsync(s => s.Id == id);
        return squad;
    }

    public async Task<Unit> Remove(Guid id)
    {
        var squad = await _limqDbContext.Squads.FirstOrDefaultAsync(s => s.Id == id);
        _limqDbContext.Squads.Remove(squad);
        return Unit.Value;
    }
}
