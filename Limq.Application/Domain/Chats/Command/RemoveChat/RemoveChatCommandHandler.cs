using Limq.Core.Common;
using Limq.Core.Domain.Chats.Common;
using MediatR;

namespace Limq.Application.Domain.Chats.Command.RemoveChat;
public class RemoveChatCommandHandler : IRequestHandler<RemoveChatCommand, Unit>
{
    private readonly IChatRepository _chatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveChatCommandHandler(IChatRepository chatRepository, IUnitOfWork unitOfWork)
    {
        _chatRepository = chatRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(RemoveChatCommand command, CancellationToken cancellationToken)
    {
        await _chatRepository.Remove(command.FirstUser, command.SecondUser);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
