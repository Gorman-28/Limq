using MediatR;

namespace Limq.Application.Domain.Users.Command.ChangeUser;
public record ChangePasswordCommand(Guid Id, string NewPassword) : IRequest<Unit>;
