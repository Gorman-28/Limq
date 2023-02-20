using MediatR;

namespace Limq.Application.Domain.Users.Command.ChangeUser;
public record ChangeStatusCommand(Guid Id, bool Status) : IRequest<Unit>;
