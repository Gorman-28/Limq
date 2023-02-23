using Limq.Core.Common;
using Limq.Core.Domain.Chats.Common;
using Limq.Core.Domain.Users.Common;
using Limq.Core.Domain.Users.Models;
using MediatR;

namespace Limq.Application.Domain.UserChatsBlocked.Command.CreateUserChatBlocked;
public class CreateUserChatBlockedCommandHandler : IRequestHandler<CreateUserChatBlockedCommand, Unit>
{
    private readonly IUserChatBlockedRepository _userChatBlockedRepository;
    private readonly IChatRepository _chatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserChatBlockedCommandHandler(IUserChatBlockedRepository userChatBlockedRepository, IChatRepository chatRepository, IUnitOfWork unitOfWork)
    {
        _userChatBlockedRepository = userChatBlockedRepository;
        _chatRepository = chatRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(CreateUserChatBlockedCommand command, CancellationToken cancellationToken)
    {
        var userChatBlocked = UserChatBlocked.Create(command.FirstUser, command.SecondUser);
        await _userChatBlockedRepository.Add(userChatBlocked);
        await _chatRepository.Remove(command.FirstUser, command.SecondUser);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
