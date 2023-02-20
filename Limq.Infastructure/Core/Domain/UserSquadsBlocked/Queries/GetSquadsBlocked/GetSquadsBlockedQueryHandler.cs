using Limq.Application.Domain.UserSquadsBlocked.Queries.GetSquadsBlocked;
using Limq.Persistence.LimqDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Limq.Infastructure.Core.Domain.UserSquadsBlocked.Queries.GetSquadsBlocked;
public class GetSquadsBlockedQueryHandler : IRequestHandler<GetSquadsBlockedQuery, GetSquadsBlockedDto[]>
{
    private readonly LimqDbContext _limqDbContext;

    public GetSquadsBlockedQueryHandler(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }
    public async Task<GetSquadsBlockedDto[]> Handle(GetSquadsBlockedQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = from cb in _limqDbContext.UserSquadsBlocked.Where(cb => cb.UserId == request.Id)
                       join s in _limqDbContext.Squads on cb.SquadId equals s.Id
                       from ms in _limqDbContext.MessagesSquad.Where(ms => ms.SquadId == cb.SquadId).OrderBy(ms => ms.MessageTime)
                       select new GetSquadsBlockedDto
                       {
                           Id = s.Id,
                           Name = s.Name,
                           Avatar = s.Avatar
                       };

        var data = await sqlQuery
            .AsNoTracking()
            .OrderBy(s => s.Name)
            .ToArrayAsync(cancellationToken);

        return data;
    }
}
