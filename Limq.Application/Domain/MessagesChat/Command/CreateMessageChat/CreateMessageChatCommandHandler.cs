using Limq.Core.Common;
using Limq.Core.Domain.Messages.Common;
using Limq.Core.Domain.Messages.Models;
using MediatR;

namespace Limq.Application.Domain.MessagesChat.Command.CreateMessageChat;
public class CreateMessageChatCommandHandler : IRequestHandler<CreateMessageChatCommand, Unit>
{
    private readonly IMessageChatRepository _messageChatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMessageChatCommandHandler(IMessageChatRepository messageChatRepository, IUnitOfWork unitOfWork)
    {
        _messageChatRepository = messageChatRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(CreateMessageChatCommand command, CancellationToken cancellationToken)
    {
        var message = MessageChat.Create(command.UserFromId, command.UserToId, command.Message, command.MessageTime);
        await _messageChatRepository.Add(message);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
