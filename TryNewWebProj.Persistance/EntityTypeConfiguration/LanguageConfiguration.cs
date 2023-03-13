using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Persistance.EntityTypeConfiguration
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(lang => lang.Id);
            builder.HasIndex(lang => lang.Id);
            builder.Property(lang => lang.Title).HasMaxLength(30);


        }
    }
}