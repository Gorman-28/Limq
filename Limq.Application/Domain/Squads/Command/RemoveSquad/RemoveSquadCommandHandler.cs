using Limq.Core.Common;
using Limq.Core.Domain.Squads.Common;
using Limq.Core.Domain.Users.Common;
using MediatR;

namespace Limq.Application.Domain.Squads.Command.RemoveSquad;
public class RemoveSquadCommandHandler : IRequestHandler<RemoveSquadCommand, Unit>
{
    private readonly ISquadRepository _squadRepository;
    private readonly IUserSquadRepository _userSquadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveSquadCommandHandler(ISquadRepository squadRepository, IUserSquadRepository userSquadRepository, IUnitOfWork unitOfWork)
    {
        _squadRepository = squadRepository;
        _userSquadRepository = userSquadRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(RemoveSquadCommand command, CancellationToken cancellationToken)
    {
        await _squadRepository.Remove(command.Id);
        await _userSquadRepository.RemoveRangeSquad(command.Id);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
