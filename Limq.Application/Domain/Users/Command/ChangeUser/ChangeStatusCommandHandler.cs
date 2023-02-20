using Limq.Core.Common;
using Limq.Core.Domain.Users.Common;
using MediatR;

namespace Limq.Application.Domain.Users.Command.ChangeUser;
public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeStatusCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(ChangeStatusCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Find(command.Id);
        user.Status = command.Status;
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
