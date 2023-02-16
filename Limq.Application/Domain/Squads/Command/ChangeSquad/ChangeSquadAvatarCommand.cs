using MediatR;

namespace Limq.Application.Domain.Squads.Command.ChangeSquad;
public record ChangeSquadAvatarCommand(Guid Id, List<byte> NewAvatar) : IRequest<Unit>;

