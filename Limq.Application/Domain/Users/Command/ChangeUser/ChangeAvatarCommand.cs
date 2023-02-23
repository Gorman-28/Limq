using MediatR;

namespace Limq.Application.Domain.Users.Command.ChangeUser;
#pragma warning disable CA1819 // Properties should not return arrays
public record ChangeAvatarCommand(Guid Id, byte[] Avatar) : IRequest<Unit>;
#pragma warning restore CA1819 // Properties should not return arrays
