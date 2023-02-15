using Limq.Core.Domain.Groups.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Limq.Persistence.LimqDb.EntityConfigurations;
public class SquadEntityConfiguration : IEntityTypeConfiguration<Squad>
{
    public void Configure(EntityTypeBuilder<Squad> builder)
    {
        builder.HasKey(g => g.Id);
    }
}
