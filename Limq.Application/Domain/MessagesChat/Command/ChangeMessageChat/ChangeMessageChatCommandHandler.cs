using Limq.Core.Common;
using Limq.Core.Domain.Messages.Common;
using MediatR;

namespace Limq.Application.Domain.MessagesChat.Command.ChangeMessageChat;
public class ChangeMessageChatCommandHandler : IRequestHandler<ChangeMessageSquadCommand, Unit>
{
    private readonly IMessageChatRepository _messageChatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeMessageChatCommandHandler(IMessageChatRepository messageChatRepository, IUnitOfWork unitOfWork)
    {
        _messageChatRepository = messageChatRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(ChangeMessageSquadCommand command, CancellationToken cancellationToken)
    {
        var chat = await _messageChatRepository.Find(command.UserFromId, command.UserToId, command.Time);
        chat.Message = command.Message;
        chat.MessageTime = command.NewTime;
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
