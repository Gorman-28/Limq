using Limq.Core.Common;
using Limq.Core.Domain.Squads.Common;
using MediatR;

namespace Limq.Application.Domain.Squads.Command.ChangeSquad;
public class ChangeSquadNameCommandHandler : IRequestHandler<ChangeSquadNameCommand, Unit>
{
    private readonly ISquadRepository _squadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeSquadNameCommandHandler(ISquadRepository squadRepository, IUnitOfWork unitOfWork)
    {
        _squadRepository = squadRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(ChangeSquadNameCommand command, CancellationToken cancellationToken)
    {
        var squad = await _squadRepository.Find(command.Id);
        squad.Name = command.NewName;
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
