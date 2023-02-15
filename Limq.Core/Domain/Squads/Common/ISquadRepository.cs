using Limq.Core.Domain.Squads.Models;
using MediatR;

namespace Limq.Core.Domain.Squads.Common;
public interface ISquadRepository
{
    Task<Unit> Add(Squad squad);

    Task<Squad> Find(Guid id);

    Task<Unit> Remove(Guid id);
}
