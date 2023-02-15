using MediatR;

namespace Limq.Core.Common;
public interface IUnitOfWork
{
    Task<Unit> SaveChanges();
}
