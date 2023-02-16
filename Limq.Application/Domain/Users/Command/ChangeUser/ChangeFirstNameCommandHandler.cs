using Limq.Core.Common;
using Limq.Core.Domain.Users.Common;
using MediatR;

namespace Limq.Application.Domain.Users.Command.ChangeUser;
public class ChangeFirstNameCommandHandler : IRequestHandler<ChangeFirstNameCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeFirstNameCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(ChangeFirstNameCommand command, CancellationToken cancellationToken)
    {
        var chat = await _userRepository.Find(command.Id);
        chat.FirstName = command.NewFirstName;
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
