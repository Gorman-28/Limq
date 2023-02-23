namespace Limq.Application.Domain.MessagesSquad.Queries.GetMessagesSquad;
public record GetMessagesSquadDto
{
    public Guid UserFromId { get; set; }

    public string UserName { get; set; }


#pragma warning disable CA1819 // Properties should not return arrays
    public byte[] Avatar { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays


    public string Message { get; set; }

    public DateTimeOffset MessageTime { get; set; }

    public bool SystemMessage { get; set; }
}
