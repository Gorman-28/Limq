using Limq.Core.Common;
using Limq.Core.Domain.Squads.Common;
using MediatR;

namespace Limq.Application.Domain.Squads.Command.ChangeSquad;
public class ChangeSquadAvatarCommandHandler : IRequestHandler<ChangeSquadAvatarCommand, Unit>
{
    private readonly ISquadRepository _squadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeSquadAvatarCommandHandler(ISquadRepository squadRepository, IUnitOfWork unitOfWork)
    {
        _squadRepository = squadRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(ChangeSquadAvatarCommand command, CancellationToken cancellationToken)
    {
        var squad = await _squadRepository.Find(command.Id);
        squad.Avatar = command.NewAvatar;
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
