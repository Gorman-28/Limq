using Limq.Application.Domain.MessagesSquad.Queries.GetMessagesSquad;
using Limq.Persistence.LimqDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Limq.Infastructure.Core.Domain.MessagesSquad.Queries.GetMessagesSquad;
public class GetMessagesSquadQueryHandler : IRequestHandler<GetMessagesSquadQuery, GetMessagesSquadDto[]>
{
    private readonly LimqDbContext _limqDbContext;

    public GetMessagesSquadQueryHandler(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }
    public async Task<GetMessagesSquadDto[]> Handle(GetMessagesSquadQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = from ms in _limqDbContext.MessagesSquad.Where(ms => ms.SquadId == request.SquadId)
                       join u in _limqDbContext.Users on ms.UserFromId equals u.Id
                       select new GetMessagesSquadDto
                       {
                           UserFromId = ms.UserFromId,
                           UserName = u.UserName,
                           Avatar = u.Avatar,
                           Message = ms.Message,
                           MessageTime = ms.MessageTime
                       };

        var data = await sqlQuery
            .AsNoTracking()
            .OrderBy(ms => ms.MessageTime)
            .ToArrayAsync(cancellationToken);

        return data;
    }
}
