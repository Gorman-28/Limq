using Limq.Core.Common;
using Limq.Core.Domain.Users.Common;
using MediatR;

namespace Limq.Application.Domain.UsersSquad.Command.RemoveUserSquad;
public class RemoveUserSquadCommandHandler : IRequestHandler<RemoveUserSquadCommand, Unit>
{
    private readonly IUserSquadRepository _userSquadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveUserSquadCommandHandler(IUserSquadRepository userSquadRepository, IUnitOfWork unitOfWork)
    {
        _userSquadRepository = userSquadRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(RemoveUserSquadCommand command, CancellationToken cancellationToken)
    {
        await _userSquadRepository.Remove(command.UserId, command.SquadId);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
