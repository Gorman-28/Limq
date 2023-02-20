using Limq.Core.Domain.Messages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Limq.Persistence.LimqDb.EntityConfigurations;
public class MessageSquadEntityConfiguration : IEntityTypeConfiguration<MessageSquad>
{
    public void Configure(EntityTypeBuilder<MessageSquad> builder)
    {
        builder.HasKey(ms => ms.Id);
    }
}
