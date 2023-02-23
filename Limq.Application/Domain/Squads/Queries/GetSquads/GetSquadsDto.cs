namespace Limq.Application.Domain.Squads.Queries.GetSquads;
public record GetSquadsDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

#pragma warning disable CA1819 // Properties should not return arrays
    public byte[] Avatar { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays

    public Guid AdminId { get; set; }

    public string Message { get; set; }

    public DateTimeOffset MessageTime { get; set; }

    public bool SystemMessage { get; set; }
}
