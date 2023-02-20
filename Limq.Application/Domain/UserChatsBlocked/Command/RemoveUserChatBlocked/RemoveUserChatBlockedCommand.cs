using MediatR;

namespace Limq.Application.Domain.UserChatsBlocked.Command.RemoveUserChatBlocked;
public record RemoveUserChatBlockedCommand(Guid FirstUserId, Guid SecondUserId) : IRequest<Unit>;
