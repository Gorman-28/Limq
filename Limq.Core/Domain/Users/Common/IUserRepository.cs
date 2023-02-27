using Limq.Core.Domain.Users.Models;
using MediatR;

namespace Limq.Core.Domain.Users.Common;
public interface IUserRepository
{
    Task<Unit> Add(User user);

    Task<User> Find(string name);

    Task<User> Find(string name, string password);

    Task<User> Find(Guid id);

    Task<Unit> Remove(Guid id);
}
