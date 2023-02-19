using Limq.Core.Common;
using Limq.Core.Domain.Chats.Common;
using Limq.Core.Domain.Messages.Common;
using Limq.Core.Domain.Users.Common;
using MediatR;

namespace Limq.Application.Domain.Users.Command.RemoveUser;
public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IChatRepository _chatRepository;
    private readonly IMessageChatRepository _messageChatRepository;
    private readonly IMessageSquadRepository _messageSquadRepository;
    private readonly IUserSquadRepository _userSquadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveUserCommandHandler(IUserRepository userRepository, IChatRepository chatRepository, IMessageChatRepository messageChatRepository, IMessageSquadRepository messageSquadRepository, IUserSquadRepository userSquadRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _chatRepository = chatRepository;
        _messageChatRepository = messageChatRepository;
        _messageSquadRepository = messageSquadRepository;
        _userSquadRepository = userSquadRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(RemoveUserCommand command, CancellationToken cancellationToken)
    {
        await _userRepository.Remove(command.Id);
        await _chatRepository.RemoveRange(command.Id);
        await _messageChatRepository.RemoveRangeFromUser(command.Id);
        await _messageSquadRepository.RemoveRangeFromUser(command.Id);
        await _userSquadRepository.RemoveRange(command.Id);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
