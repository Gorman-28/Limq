namespace Limq.Application.Domain.UserSquadsBlocked.Queries.GetSquadsBlocked;
public record GetSquadsBlockedDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

#pragma warning disable CA1819 // Properties should not return arrays
    public byte[] Avatar { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays

    public Guid AdminId { get; set; }

}
