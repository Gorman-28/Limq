using MediatR;

namespace Limq.Application.Domain.Squads.Command.CreateSquad;
public record CreateSquadCommand(string Name, List<byte> Avatar, Guid AdminId) : IRequest<Unit>;
