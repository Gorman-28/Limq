using Limq.Core.Common;
using Limq.Core.Domain.Messages.Common;
using MediatR;

namespace Limq.Application.Domain.MessagesChat.Command.RemoveMessageChat;
public class RemoveMessageChatCommandHandler : IRequestHandler<RemoveMessageChatCommand, Unit>
{
    private readonly IMessageChatRepository _messageChatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveMessageChatCommandHandler(IMessageChatRepository messageChatRepository, IUnitOfWork unitOfWork)
    {
        _messageChatRepository = messageChatRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(RemoveMessageChatCommand command, CancellationToken cancellationToken)
    {
        await _messageChatRepository.Remove(command.UserFromId, command.UserToId, command.Time);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
