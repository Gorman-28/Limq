using MediatR;

namespace Limq.Application.Domain.Chats.Command.CreateChat;
public record CreateChatCommand(Guid FirstUser, Guid SecondUser) : IRequest<Unit>;
