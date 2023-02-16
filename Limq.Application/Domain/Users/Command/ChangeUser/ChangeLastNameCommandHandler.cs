using Limq.Core.Common;
using Limq.Core.Domain.Users.Common;
using MediatR;

namespace Limq.Application.Domain.Users.Command.ChangeUser;
public class ChangeLastNameCommandHandler : IRequestHandler<ChangeLastNameCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeLastNameCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(ChangeLastNameCommand command, CancellationToken cancellationToken)
    {
        var chat = await _userRepository.Find(command.Id);
        chat.LastName = command.NewLastName;
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
