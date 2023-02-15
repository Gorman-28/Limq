using Limq.Core.Common;
using Limq.Core.Domain.Chats.Common;
using Limq.Core.Domain.Chats.Models;
using MediatR;

namespace Limq.Application.Domain.Chats.Command.CreateChat;
public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, Unit>
{
    private readonly IChatRepository _chatrepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateChatCommandHandler(IChatRepository chatrepository, IUnitOfWork unitOfWork)
    {
        _chatrepository = chatrepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(CreateChatCommand command, CancellationToken cancellationToken)
    {
        var chat = Chat.Create(command.FirstUser, command.SecondUser);
        await _chatrepository.Add(chat);
        await _unitOfWork.SaveChanges();
        return Unit.Value;
    }
}
