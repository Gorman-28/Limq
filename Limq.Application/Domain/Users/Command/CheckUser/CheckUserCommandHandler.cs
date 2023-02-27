using Limq.Core.Domain.Users.Common;
using Limq.Core.Domain.Users.Models;
using MediatR;

namespace Limq.Application.Domain.Users.Command.CheckUser;
public class CheckUserCommandHandler : IRequestHandler<CheckUserCommand, User>
{
    private readonly IUserRepository _userRepository;

    public CheckUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User> Handle(CheckUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Find(command.Name);
        return user;
    }
}
