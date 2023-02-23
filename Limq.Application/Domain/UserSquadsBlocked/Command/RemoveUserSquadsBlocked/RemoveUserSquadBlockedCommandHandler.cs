using Limq.Core.Common;
using Limq.Core.Domain.Users.Common;
using Limq.Core.Domain.Users.Models;
using MediatR;

namespace Limq.Application.Domain.UserSquadsBlocked.Command.RemoveUserSquadsBlocked;
public class RemoveUserSquadBlockedCommandHandler : IRequestHandler<RemoveUserSquadBlockedCommand, Unit>
{
    private readonly IUserSquadBlockedRepository _userSquadBlockedRepository;
    private readonly IUserSquadRepository _userSquadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveUserSquadBlockedCommandHandler(IUserSquadBlockedRepository userSquadBlockedRepository, IUserSquadRepository userSquadRepository, IUnitOfWork unitOfWork)
    {
        _userSquadBlockedRepository = userSquadBlockedRepository;
        _userSquadRepository = userSquadRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(RemoveUserSquadBlockedCommand command, CancellationToken cancellationToken)
    {
        await _userSquadBlockedRepository.Remove(command.UserId, command.SquadId);
        var userSquad = UserSquad.Create(command.UserId, command.SquadId);
        await _userSquadRepository.Add(userSquad);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
