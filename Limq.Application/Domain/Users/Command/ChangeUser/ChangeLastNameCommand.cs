using MediatR;

namespace Limq.Application.Domain.Users.Command.ChangeUser;
public record ChangeLastNameCommand(Guid Id, string NewLastName) : IRequest<Unit>;
