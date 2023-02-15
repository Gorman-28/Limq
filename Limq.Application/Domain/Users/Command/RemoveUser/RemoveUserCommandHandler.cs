using Limq.Core.Common;
using Limq.Core.Domain.Chats.Common;
using Limq.Core.Domain.Users.Common;
using MediatR;

namespace Limq.Application.Domain.Users.Command.RemoveUser;
public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IChatRepository _chatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveUserCommandHandler(IUserRepository userRepository, IChatRepository chatRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _chatRepository = chatRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(RemoveUserCommand command, CancellationToken cancellationToken)
    {
        await _userRepository.Remove(command.Id);
        await _chatRepository.Remove(command.Id);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
