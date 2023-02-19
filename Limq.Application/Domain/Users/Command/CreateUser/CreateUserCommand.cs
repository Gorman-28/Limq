using MediatR;

namespace Limq.Application.Domain.Users.Command.CreateUser;
public record CreateUserCommand(string UserName, string Password, string FirstName, string LastName, List<byte> Avatar) : IRequest<Unit>
