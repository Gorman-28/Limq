namespace Limq.Application.Domain.MessagesSquad.Queries.GetMessagesSquad;
public record GetMessagesSquadDto
{
    public Guid UserFromId { get; set; }

    public string UserName { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
    public List<byte> Avatar { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

    public string Message { get; set; }

    public DateTimeOffset MessageTime { get; set; }
}
