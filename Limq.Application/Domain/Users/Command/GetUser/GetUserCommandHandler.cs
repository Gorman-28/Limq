using Limq.Core.Domain.Users.Common;
using Limq.Core.Domain.Users.Models;
using MediatR;

namespace Limq.Application.Domain.Users.Command.GetUser;
public class GetUserCommandHandler : IRequestHandler<GetUserCommand, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User> Handle(GetUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Find(command.Name, command.Password);
        return user;
    }
}
