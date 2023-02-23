using Limq.Application.Domain.Squads.Queries.GetSquads;
using Limq.Persistence.LimqDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Limq.Infastructure.Core.Domain.Squads.Queries.GetSquads;
public class GetSquadsQueryHandler : IRequestHandler<GetSquadsQuery, GetSquadsDto[]>
{
    private readonly LimqDbContext _limqDbContext;

    public GetSquadsQueryHandler(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }
    public async Task<GetSquadsDto[]> Handle(GetSquadsQuery request, CancellationToken cancellationToken)
    {
        var sqlquery = from us in _limqDbContext.UserSquads.Where(us => us.UserId == request.UserId)
                       from ms in _limqDbContext.MessagesSquad.Where(ms => ms.SquadId == us.SquadId).OrderByDescending(ms => ms.MessageTime).Skip(0).Take(1)
                       join s in _limqDbContext.Squads on us.SquadId equals s.Id
                       select new GetSquadsDto
                       {
                           Id = s.Id,
                           Name = s.Name,
                           Avatar = s.Avatar,
                           AdminId = s.AdminId,
                           Message = ms.Message,
                           MessageTime = ms.MessageTime,
                           SystemMessage = ms.SystemMessage
                       };

        var data = await sqlquery
            .AsNoTracking()
            .OrderBy(ms => ms.MessageTime)
            .ToArrayAsync(cancellationToken);

        return data;
    }
}
