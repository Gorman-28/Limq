using Limq.Core.Common;
using Limq.Core.Domain.Users.Common;
using Limq.Core.Domain.Users.Models;
using MediatR;

namespace Limq.Application.Domain.Users.Command.CreateUser;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = User.Create(command.UserName, command.Password, command.FirstName, command.LastName, command.Avatar);
        await _userRepository.Add(user);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
