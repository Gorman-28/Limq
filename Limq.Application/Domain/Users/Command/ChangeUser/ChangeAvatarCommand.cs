using MediatR;

namespace Limq.Application.Domain.Users.Command.ChangeUser;
public record ChangeAvatarCommand(Guid Id, List<byte> Avatar) : IRequest<Unit>;
