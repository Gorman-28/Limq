namespace Limq.Application.Domain.Chats.Queries.GetAllChats;
public record GetAllChatsDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
#pragma warning disable CA1819 // Properties should not return arrays
    public byte[] Avatar { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays

    public bool Status { get; set; }

    public string Message { get; set; }

    public DateTimeOffset MessageTime { get; set; }
}
