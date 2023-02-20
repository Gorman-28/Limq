using Limq.Core.Common;
using Limq.Core.Domain.Users.Common;
using MediatR;

namespace Limq.Application.Domain.UserChatsBlocked.Command.RemoveUserChatBlocked;
public class RemoveUserChatBlockedCommandHandler : IRequestHandler<RemoveUserChatBlockedCommand, Unit>
{
    private readonly IUserChatBlockedRepository _userChatBlockedRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveUserChatBlockedCommandHandler(IUserChatBlockedRepository userChatBlockedRepository, IUnitOfWork unitOfWork)
    {
        _userChatBlockedRepository = userChatBlockedRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(RemoveUserChatBlockedCommand command, CancellationToken cancellationToken)
    {
        await _userChatBlockedRepository.Remove(command.FirstUserId, command.SecondUserId);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
