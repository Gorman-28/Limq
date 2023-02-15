using Limq.Core.Common;
using Limq.Persistence.LimqDb;
using MediatR;

namespace Limq.Infastructure.Core.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly LimqDbContext _limqDbContext;

    public UnitOfWork(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }
    public async Task<Unit> SaveChanges()
    {
        await _limqDbContext.SaveChangesAsync();
        return Unit.Value;
    }
}
