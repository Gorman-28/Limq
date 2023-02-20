using MediatR;

namespace Limq.Application.Domain.UserChatsBlocked.Command.CreateUserChatBlocked;
public record CreateUserChatBlockedCommand(Guid FirstUser, Guid SecondUser) : IRequest<Unit>;
