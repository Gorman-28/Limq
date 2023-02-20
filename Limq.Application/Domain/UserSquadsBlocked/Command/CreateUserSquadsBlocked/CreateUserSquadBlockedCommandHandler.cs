using Limq.Core.Common;
using Limq.Core.Domain.Users.Common;
using Limq.Core.Domain.Users.Models;
using MediatR;

namespace Limq.Application.Domain.UserSquadsBlocked.Command.CreateUserSquadsBlocked;
public class CreateUserSquadBlockedCommandHandler : IRequestHandler<CreateUserSquadBlockedCommand, Unit>
{
    private readonly IUserSquadBlockedRepository _userSquadBlockedRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserSquadBlockedCommandHandler(IUserSquadBlockedRepository userSquadBlockedRepository, IUnitOfWork unitOfWork)
    {
        _userSquadBlockedRepository = userSquadBlockedRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(CreateUserSquadBlockedCommand command, CancellationToken cancellationToken)
    {
        var userSquadBlocked = UserSquadBlocked.Create(command.UserId, command.SquadId);
        await _userSquadBlockedRepository.Add(userSquadBlocked);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
