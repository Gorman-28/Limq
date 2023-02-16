using Limq.Core.Common;
using Limq.Core.Domain.Messages.Common;
using MediatR;

namespace Limq.Application.Domain.MessagesSquad.Command.RemoveMessageSquad;
public class RemoveMessageSquadCommandHandler : IRequestHandler<RemoveMessageSquadCommand, Unit>
{
    private readonly IMessageSquadRepository _messageSquadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveMessageSquadCommandHandler(IMessageSquadRepository messageSquadRepository, IUnitOfWork unitOfWork)
    {
        _messageSquadRepository = messageSquadRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(RemoveMessageSquadCommand command, CancellationToken cancellationToken)
    {
        await _messageSquadRepository.Remove(command.SquadId, command.UserFromId, command.Time);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
