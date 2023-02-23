using MediatR;

namespace Limq.Application.Domain.Squads.Command.ChangeSquad;
#pragma warning disable CA1819 // Properties should not return arrays
public record ChangeSquadAvatarCommand(Guid Id, byte[] NewAvatar) : IRequest<Unit>;
#pragma warning restore CA1819 // Properties should not return arrays

