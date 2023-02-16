using Limq.Core.Common;
using Limq.Core.Domain.Messages.Common;
using MediatR;

namespace Limq.Application.Domain.MessagesSquad.Command.ChangeMessageSquad;
public class ChangeMessageSquadCommandHandler : IRequestHandler<ChangeMessageSquadCommand, Unit>
{
    private readonly IMessageSquadRepository _messageSquadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeMessageSquadCommandHandler(IMessageSquadRepository messageSquadRepository, IUnitOfWork unitOfWork)
    {
        _messageSquadRepository = messageSquadRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(ChangeMessageSquadCommand command, CancellationToken cancellationToken)
    {
        var squad = await _messageSquadRepository.Find(command.SquadId, command.UserFromId, command.Time);
        squad.Message = command.Message;
        squad.MessageTime = command.NewTime;
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
