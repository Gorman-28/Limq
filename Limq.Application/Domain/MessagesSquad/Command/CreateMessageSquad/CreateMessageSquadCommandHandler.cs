using Limq.Core.Common;
using Limq.Core.Domain.Messages.Common;
using Limq.Core.Domain.Messages.Models;
using MediatR;

namespace Limq.Application.Domain.MessagesSquad.Command.CreateMessageSquad;
public class CreateMessageSquadCommandHandler : IRequestHandler<CreateMessageSquadCommand, Unit>
{
    private readonly IMessageSquadRepository _messageSquadRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMessageSquadCommandHandler(IMessageSquadRepository messageSquadRepository, IUnitOfWork unitOfWork)
    {
        _messageSquadRepository = messageSquadRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(CreateMessageSquadCommand command, CancellationToken cancellationToken)
    {
        var messageSquad = MessageSquad.Create(command.SquadId, command.UserFromId, command.Message, command.MessageTime);
        await _messageSquadRepository.Add(messageSquad);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
