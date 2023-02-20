using Limq.Core.Domain.Users.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Limq.Persistence.LimqDb.EntityConfigurations;
public class UserChatBlockedEntityConfiguration : IEntityTypeConfiguration<UserChatBlocked>
{
    public void Configure(EntityTypeBuilder<UserChatBlocked> builder)
    {
        builder.HasKey(ucb => new { ucb.FirstUser, ucb.SecondUser });

        builder.HasOne(ucb => ucb.User1)
            .WithMany(u => u.UserChatsBlocked)
            .HasForeignKey(ucb => ucb.FirstUser);

        builder.HasOne(ucb => ucb.User2)
            .WithMany(u => u.UserChatsBlocked)
            .HasForeignKey(ucb => ucb.SecondUser);
    }
}
