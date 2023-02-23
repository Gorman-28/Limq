using Limq.Core.Common;
using Limq.Core.Domain.Chats.Common;
using Limq.Core.Domain.Chats.Models;
using Limq.Core.Domain.Users.Common;
using MediatR;

namespace Limq.Application.Domain.UserChatsBlocked.Command.RemoveUserChatBlocked;
public class RemoveUserChatBlockedCommandHandler : IRequestHandler<RemoveUserChatBlockedCommand, Unit>
{
    private readonly IUserChatBlockedRepository _userChatBlockedRepository;
    private readonly IChatRepository _chatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveUserChatBlockedCommandHandler(IUserChatBlockedRepository userChatBlockedRepository, IChatRepository chatRepository, IUnitOfWork unitOfWork)
    {
        _userChatBlockedRepository = userChatBlockedRepository;
        _chatRepository = chatRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(RemoveUserChatBlockedCommand command, CancellationToken cancellationToken)
    {
        await _userChatBlockedRepository.Remove(command.FirstUserId, command.SecondUserId);
        var chat = Chat.Create(command.FirstUserId, command.SecondUserId);
        await _chatRepository.Add(chat);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
