using Limq.Core.Common;
using Limq.Core.Domain.Users.Common;
using MediatR;

namespace Limq.Application.Domain.UserSquadsBlocked.Command.RemoveUserSquadsBlocked;
public class RemoveUserSquadBlockedCommandHandler : IRequestHandler<RemoveUserSquadBlockedCommand, Unit>
{
    private readonly IUserSquadBlockedRepository _userSquadBlockedRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveUserSquadBlockedCommandHandler(IUserSquadBlockedRepository userSquadBlockedRepository, IUnitOfWork unitOfWork)
    {
        _userSquadBlockedRepository = userSquadBlockedRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(RemoveUserSquadBlockedCommand command, CancellationToken cancellationToken)
    {
        await _userSquadBlockedRepository.Remove(command.UserId, command.SquadId);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
