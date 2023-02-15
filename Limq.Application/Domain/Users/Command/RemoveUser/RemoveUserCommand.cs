using MediatR;

namespace Limq.Application.Domain.Users.Command.RemoveUser;
public record RemoveUserCommand(Guid Id) : IRequest<Unit>;
