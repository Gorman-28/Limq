using MediatR;

namespace Limq.Application.Domain.Squads.Command.CreateSquad;
#pragma warning disable CA1819 // Properties should not return arrays
public record CreateSquadCommand(string Name, byte[] Avatar, Guid AdminId) : IRequest<Guid>;
#pragma warning restore CA1819 // Properties should not return arrays
