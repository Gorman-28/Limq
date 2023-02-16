using Limq.Core.Common;
using Limq.Core.Domain.Users.Common;
using MediatR;

namespace Limq.Application.Domain.Users.Command.ChangeUser;
public class ChangeUserNameCommandHandler : IRequestHandler<ChangeUserNameCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeUserNameCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(ChangeUserNameCommand command, CancellationToken cancellationToken)
    {
        var chat = await _userRepository.Find(command.Id);
        chat.UserName = command.NewUserName;
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
