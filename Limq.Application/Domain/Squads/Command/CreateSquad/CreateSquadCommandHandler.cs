using Limq.Core.Common;
using Limq.Core.Domain.Squads.Common;
using Limq.Core.Domain.Squads.Models;
using MediatR;

namespace Limq.Application.Domain.Squads.Command.CreateSquad;
public class CreateSquadCommandHandler : IRequestHandler<CreateSquadCommand, Unit>
{
    private readonly ISquadRepository _squadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSquadCommandHandler(ISquadRepository squadRepository, IUnitOfWork unitOfWork)
    {
        _squadRepository = squadRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(CreateSquadCommand command, CancellationToken cancellationToken)
    {
        var squad = Squad.Create(command.Name, command.Avatar, command.AdminId);
        await _squadRepository.Add(squad);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
