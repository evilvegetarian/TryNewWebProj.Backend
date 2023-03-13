using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Persistance.EntityTypeConfiguration
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.HasKey(word => word.Id);
            builder.HasIndex(word => word.Id);
            builder.Property(word => word.WordValue).HasMaxLength(250);
            builder.Property(word => word.Translate).HasMaxLength(250);

        }
    }
}