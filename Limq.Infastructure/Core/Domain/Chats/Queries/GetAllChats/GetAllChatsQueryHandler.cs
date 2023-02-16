using Limq.Application.Domain.Chats.Queries.GetAllChats;
using Limq.Persistence.LimqDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Limq.Infastructure.Core.Domain.Chats.Queries.GetAllChats;
public class GetAllChatsQueryHandler : IRequestHandler<GetAllChatsQuery, GetAllChatsDto[]>
{
    private readonly LimqDbContext _limqDbContext;

    public GetAllChatsQueryHandler(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }
    public async Task<GetAllChatsDto[]> Handle(GetAllChatsQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = from c in _limqDbContext.Chats.Where(c => c.FirstUser == request.Id)
                       join u in _limqDbContext.Users on c.SecondUser equals u.Id
                       from m in _limqDbContext.MessagesChat.Where(m => m.UserFromId == c.FirstUser && m.UserToId == c.SecondUser || m.UserFromId == c.SecondUser && m.UserToId == c.FirstUser).OrderBy(m => m.MessageTime)
                       select new GetAllChatsDto
                       {
                           UserName = u.UserName,
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           Avatar = u.Avatar,
                           Status = u.Status,
                           Message = m.Message,
                           MessageTime = m.MessageTime
                       };
        var data = await sqlQuery
            .AsNoTracking()
            .OrderBy(m => m.MessageTime)
            .ToArrayAsync(cancellationToken);

        return data;
    }
}
