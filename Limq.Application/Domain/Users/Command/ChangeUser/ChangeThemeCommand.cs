using MediatR;

namespace Limq.Application.Domain.Users.Command.ChangeUser;
public record ChangeThemeCommand(Guid Id, bool Theme) : IRequest<Unit>;
