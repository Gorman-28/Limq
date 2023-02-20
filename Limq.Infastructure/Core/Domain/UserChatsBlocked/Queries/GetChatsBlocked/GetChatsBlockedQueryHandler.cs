using Limq.Application.Domain.UserChatsBlocked.Queries.GetChatsBlocked;
using Limq.Persistence.LimqDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Limq.Infastructure.Core.Domain.UserChatsBlocked.Queries.GetChatsBlocked;
public class GetChatsBlockedQueryHandler : IRequestHandler<GetChatsBlockedQuery, GetChatsBlockedDto[]>
{
    private readonly LimqDbContext _limqDbContext;

    public GetChatsBlockedQueryHandler(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }
    public async Task<GetChatsBlockedDto[]> Handle(GetChatsBlockedQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = from cb in _limqDbContext.UserChatsBlocked.Where(cb => cb.FirstUser == request.Id)
                       join u in _limqDbContext.Users on cb.SecondUser equals u.Id
                       from m in _limqDbContext.MessagesChat.Where(m => m.UserFromId == cb.FirstUser && m.UserToId == cb.SecondUser || m.UserFromId == cb.SecondUser && m.UserToId == cb.FirstUser).OrderBy(m => m.MessageTime)
                       select new GetChatsBlockedDto
                       {
                           Id = u.Id,
                           UserName = u.UserName,
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           Avatar = u.Avatar,
                           Status = u.Status,
                       };

        var data = await sqlQuery
            .AsNoTracking()
            .OrderBy(u => u.UserName)
            .ToArrayAsync(cancellationToken);

        return data;
    }
}
