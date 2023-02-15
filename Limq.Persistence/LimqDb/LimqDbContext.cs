using Limq.Core.Domain.Chats.Models;
using Limq.Core.Domain.Squads.Models;
using Limq.Core.Domain.Messages.Models;
using Limq.Core.Domain.Users.Models;
using Limq.Persistence.LimqDb.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Limq.Persistence.LimqDb;

public class LimqDbContext : DbContext
{
    public DbSet<User>? Users { get; set; }

    public DbSet<UserSquad>? UserSquads { get; set; }

    public DbSet<MessageChat>? MessagesChat { get; set; }

    public DbSet<MessageSquad>? MessagesSquad { get; set; }

    public DbSet<Squad>? Squads { get; set; }

    public DbSet<Chat>? Chats { get; set; }

    public LimqDbContext(DbContextOptions<LimqDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserGroupEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ChatEntityConfiguration());
        modelBuilder.ApplyConfiguration(new MessageChatEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SquadEntityConfiguration());
    }
}
