namespace Limq.Application.Domain.Squads.Queries.GetSquads;
public record GetSquadsDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
    public List<byte> Avatar { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

    public Guid AdminId { get; set; }

    public string Message { get; set; }

    public DateTimeOffset MessageTime { get; set; }
}
