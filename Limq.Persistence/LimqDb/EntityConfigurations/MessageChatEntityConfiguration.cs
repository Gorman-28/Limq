using Limq.Core.Domain.Messages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Limq.Persistence.LimqDb.EntityConfigurations;
public class MessageChatEntityConfiguration : IEntityTypeConfiguration<MessageChat>
{
    public void Configure(EntityTypeBuilder<MessageChat> builder)
    {
        builder.HasKey(mc => mc.Id);

    }
}
