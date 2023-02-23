using MediatR;

namespace Limq.Application.Domain.Users.Command.CreateUser;
#pragma warning disable CA1819 // Properties should not return arrays
public record CreateUserCommand(string UserName, string Password, string FirstName, string LastName, byte[] Avatar) : IRequest<Unit>;
#pragma warning restore CA1819 // Properties should not return arrays
