using Limq.Core.Common;
using Limq.Core.Domain.Users.Common;
using MediatR;

namespace Limq.Application.Domain.Users.Command.ChangeUser;
public class ChangeThemeCommandHandler : IRequestHandler<ChangeThemeCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeThemeCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(ChangeThemeCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Find(command.Id);
        user.Theme = command.Theme;
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
