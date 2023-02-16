using Limq.Core.Common;
using Limq.Core.Domain.Chats.Common;
using Limq.Core.Domain.Messages.Common;
using MediatR;

namespace Limq.Application.Domain.Chats.Command.RemoveChat;
public class RemoveChatCommandHandler : IRequestHandler<RemoveChatCommand, Unit>
{
    private readonly IChatRepository _chatRepository;
    private readonly IMessageChatRepository _messageChatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveChatCommandHandler(IChatRepository chatRepository, IMessageChatRepository messageChatRepository, IUnitOfWork unitOfWork)
    {
        _chatRepository = chatRepository;
        _messageChatRepository = messageChatRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(RemoveChatCommand command, CancellationToken cancellationToken)
    {
        await _chatRepository.Remove(command.FirstUser, command.SecondUser);
        var chat = await _chatRepository.Find(command.SecondUser, command.FirstUser);
        if (chat is null)
        {
            await _messageChatRepository.RemoveRange(command.FirstUser, command.SecondUser);
            await _messageChatRepository.RemoveRange(command.SecondUser, command.FirstUser);
        }
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
