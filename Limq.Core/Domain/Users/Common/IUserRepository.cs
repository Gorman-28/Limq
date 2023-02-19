using Limq.Core.Domain.Users.Models;
using MediatR;

namespace Limq.Core.Domain.Users.Common;
public interface IUserRepository
{
    Task<Unit> Add(User user);

    Task<User> Find(string name);

    Task<Unit> Remove(Guid id);
}
