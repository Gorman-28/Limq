namespace Limq.Application.Domain.Users.Queries.GetUsers;
public record GetUsersDto
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
    public List<byte> Avatar { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

    public bool Status { get; set; }
}
