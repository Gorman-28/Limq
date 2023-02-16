using Limq.Core.Common;
using Limq.Core.Domain.Squads.Common;
using MediatR;

namespace Limq.Application.Domain.Squads.Command.ChangeSquad;
public class ChangeSquadAdminCommandHandler : IRequestHandler<ChangeSquadAdminCommand, Unit>
{
    private readonly ISquadRepository _squadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeSquadAdminCommandHandler(ISquadRepository squadRepository, IUnitOfWork unitOfWork)
    {
        _squadRepository = squadRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(ChangeSquadAdminCommand command, CancellationToken cancellationToken)
    {
        var squad = await _squadRepository.Find(command.Id);
        squad.AdminId = command.UserId;
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
