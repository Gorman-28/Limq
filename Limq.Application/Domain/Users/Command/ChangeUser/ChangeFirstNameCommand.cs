using MediatR;

namespace Limq.Application.Domain.Users.Command.ChangeUser;
public record ChangeFirstNameCommand(Guid Id, string NewFirstName) : IRequest<Unit>;
