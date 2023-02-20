namespace Limq.Application.Domain.UserChatsBlocked.Queries.GetChatsBlocked;
public record GetChatsBlockedDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
#pragma warning disable CA2227 // Collection properties should be read only
    public List<byte> Avatar { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

    public bool Status { get; set; }

}
