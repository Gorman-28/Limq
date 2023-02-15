using MediatR;

namespace Limq.Application.Domain.Users.Command.ChangeUser;
public record ChangeUserNameCommand(Guid Id, string NewUserName) : IRequest<Unit>;
