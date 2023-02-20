using Limq.Core.Domain.Users.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Limq.Persistence.LimqDb.EntityConfigurations;
public class UserSquadBlockedEntityConfiguration : IEntityTypeConfiguration<UserSquadBlocked>
{
    public void Configure(EntityTypeBuilder<UserSquadBlocked> builder)
    {
        builder.HasKey(usb => new { usb.UserId, usb.SquadId });

        builder.HasOne(usb => usb.User)
            .WithMany(u => u.UserSquadsBlocked)
            .HasForeignKey(usb => usb.UserId);

        builder.HasOne(usb => usb.Squad)
            .WithMany(u => u.UserSquadsBlocked)
            .HasForeignKey(usb => usb.SquadId);
    }
}
