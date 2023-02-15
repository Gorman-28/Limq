using Limq.Core.Domain.Users.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Limq.Persistence.LimqDb.EntityConfigurations;
public class UserGroupEntityConfiguration : IEntityTypeConfiguration<UserSquad>
{
    public void Configure(EntityTypeBuilder<UserSquad> builder)
    {
        builder.HasKey(ug => new { ug.UserId, ug.SquadId });

        builder.HasOne(ug => ug.User)
            .WithMany(u => u.UserGroups)
            .HasForeignKey(ug => ug.UserId);

        builder.HasOne(ug => ug.Squad)
            .WithMany(g => g.UserGroups)
            .HasForeignKey(ug => ug.SquadId);
    }
}
