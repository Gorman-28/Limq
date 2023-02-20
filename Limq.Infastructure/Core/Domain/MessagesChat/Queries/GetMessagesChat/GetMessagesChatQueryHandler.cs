using Limq.Application.Domain.MessagesChat.Queries.GetMessagesChat;
using Limq.Persistence.LimqDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Limq.Infastructure.Core.Domain.MessagesChat.Queries.GetMessagesChat;
public class GetMessagesChatQueryHandler : IRequestHandler<GetMessagesChatQuery, GetMessagesChatDto[]>
{
    private readonly LimqDbContext _limqDbContext;

    public GetMessagesChatQueryHandler(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }
    public Task<GetMessagesChatDto[]> Handle(GetMessagesChatQuery request, CancellationToken cancellationToken)
    {
        var sqlQuery = _limqDbContext.MessagesChat.AsNoTracking();

        var data = sqlQuery.Where(mc => (mc.UserFromId == request.UserFromId && mc.UserToId == mc.UserToId) || (mc.UserFromId == request.UserToId && mc.UserToId == mc.UserFromId))
            .OrderByDescending(mc => mc.MessageTime)
            .Select(messageChat => new GetMessagesChatDto
            {
                UserFromId = messageChat.UserFromId,
                Message = messageChat.Message,
                MessageTime = messageChat.MessageTime
            }).ToArrayAsync(cancellationToken);

        return data;
    }
}
