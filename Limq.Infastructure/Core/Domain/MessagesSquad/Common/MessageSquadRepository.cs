using Limq.Core.Domain.Messages.Common;
using Limq.Core.Domain.Messages.Models;
using Limq.Core.Domain.Squads.Models;
using Limq.Persistence.LimqDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Limq.Infastructure.Core.Domain.MessagesSquad.Common;
public class MessageSquadRepository : IMessageSquadRepository
{
    private readonly LimqDbContext _limqDbContext;

    public MessageSquadRepository(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }
    public async Task<Unit> Add(MessageSquad messageSquad)
    {
        await _limqDbContext.MessagesSquad.AddAsync(messageSquad);
        return Unit.Value;
    }

    public async Task<MessageSquad> Find(Guid squadId, Guid userId, DateTimeOffset dateTimeOffset)
    {
        var messageSquad = await _limqDbContext.MessagesSquad.FirstOrDefaultAsync(ms => ms.SquadId == squadId && ms.UserFromId == userId && ms.MessageTime.EqualsExact(dateTimeOffset));
        return messageSquad;
    }

    public async Task<Unit> Remove(Guid squadId, Guid userId, DateTimeOffset dateTimeOffset)
    {
        var messageSquad = await _limqDbContext.MessagesSquad.FirstOrDefaultAsync(ms => ms.SquadId == squadId && ms.UserFromId == userId && ms.MessageTime.EqualsExact(dateTimeOffset));
        _limqDbContext.MessagesSquad.Remove(messageSquad);
        return Unit.Value;
    }

    public async Task<Unit> RemoveRange(Guid squadId)
    {
        var messageSquad = await _limqDbContext.MessagesSquad.Where(ms => ms.SquadId == squadId).ToListAsync();
        _limqDbContext.MessagesSquad.RemoveRange(messageSquad);
        return Unit.Value;
    }

    public async Task<Unit> RemoveRangeFromUser(Guid userId)
    {
        var messageSquad = await _limqDbContext.MessagesSquad.Where(ms => ms.UserFromId == userId).ToListAsync();
        _limqDbContext.MessagesSquad.RemoveRange(messageSquad);
        return Unit.Value;
    }
}
