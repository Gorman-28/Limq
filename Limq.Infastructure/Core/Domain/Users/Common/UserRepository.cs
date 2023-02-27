
using Limq.Core.Domain.Users.Common;
using Limq.Core.Domain.Users.Models;
using Limq.Persistence.LimqDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Limq.Infastructure.Core.Domain.Users.Common;
public class UserRepository : IUserRepository
{
    private readonly LimqDbContext _limqDbContext;

    public UserRepository(LimqDbContext limqDbContext)
    {
        _limqDbContext = limqDbContext;
    }
    public async Task<Unit> Add(User user)
    {
        await _limqDbContext.Users.AddAsync(user);
        return Unit.Value;
    }

    public async Task<User> Find(string name)
    {
        var user = await _limqDbContext.Users.FirstOrDefaultAsync(u => u.UserName == name);
        return user ?? null;
    }

    public async Task<User> Find(string name, string password)
    {
        var user = await _limqDbContext.Users.FirstOrDefaultAsync(u => u.UserName == name && u.Password == password);
        return user ?? null;
    }

    public async Task<User> Find(Guid id)
    {
        var user = await _limqDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<Unit> Remove(Guid id)
    {
        var user = await _limqDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        _limqDbContext.Users.Remove(user);
        return Unit.Value;
    }
}
