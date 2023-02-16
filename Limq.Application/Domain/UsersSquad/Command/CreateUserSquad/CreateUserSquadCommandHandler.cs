using Limq.Core.Common;
using Limq.Core.Domain.Users.Common;
using Limq.Core.Domain.Users.Models;
using MediatR;

namespace Limq.Application.Domain.UsersSquad.Command.CreateUserSquad;
public class CreateUserSquadCommandHandler : IRequestHandler<CreateUserSquadCommand, Unit>
{
    private readonly IUserSquadRepository _userSquadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserSquadCommandHandler(IUserSquadRepository userSquadRepository, IUnitOfWork unitOfWork)
    {
        _userSquadRepository = userSquadRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(CreateUserSquadCommand command, CancellationToken cancellationToken)
    {
        var userSquad = UserSquad.Create(command.UserId, command.SquadId);
        await _userSquadRepository.Add(userSquad);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
