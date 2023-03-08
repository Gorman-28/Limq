using Limq.Core.Common;
using Limq.Core.Domain.Squads.Common;
using Limq.Core.Domain.Squads.Models;
using Limq.Core.Domain.Users.Common;
using Limq.Core.Domain.Users.Models;
using MediatR;

namespace Limq.Application.Domain.Squads.Command.CreateSquad;
public class CreateSquadCommandHandler : IRequestHandler<CreateSquadCommand, Guid>
{
    private readonly ISquadRepository _squadRepository;
    private readonly IUserSquadRepository _userSquadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSquadCommandHandler(ISquadRepository squadRepository, IUserSquadRepository userSquadRepository, IUnitOfWork unitOfWork)
    {
        _squadRepository = squadRepository;
        _userSquadRepository = userSquadRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Guid> Handle(CreateSquadCommand command, CancellationToken cancellationToken)
    {
        var squad = Squad.Create(command.Name, command.Avatar, command.AdminId);
        var userSquad = UserSquad.Create(command.AdminId, squad.Id);
        await _userSquadRepository.Add(userSquad);
        await _squadRepository.Add(squad);
        await _unitOfWork.SaveChanges();
        return squad.Id;
    }
}
