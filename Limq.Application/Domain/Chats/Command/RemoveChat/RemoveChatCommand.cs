using MediatR;

namespace Limq.Application.Domain.Chats.Command.RemoveChat;
public record RemoveChatCommand(Guid FirstUser, Guid SecondUser) : IRequest<Unit>;
