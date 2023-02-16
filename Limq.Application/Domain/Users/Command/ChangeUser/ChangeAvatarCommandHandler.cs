using Limq.Core.Common;
using Limq.Core.Domain.Users.Common;
using MediatR;

namespace Limq.Application.Domain.Users.Command.ChangeUser;
public class ChangeAvatarCommandHandler : IRequestHandler<ChangeAvatarCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeAvatarCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(ChangeAvatarCommand command, CancellationToken cancellationToken)
    {
        var chat = await _userRepository.Find(command.Id);
        chat.Avatar = command.Avatar;
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
