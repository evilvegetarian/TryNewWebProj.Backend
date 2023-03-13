using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Persistance.EntityTypeConfiguration
{
    public class SettingsConfiguration : IEntityTypeConfiguration<SettingsWord>
    {
        public void Configure(EntityTypeBuilder<SettingsWord> builder)
        {
            builder.HasKey(sett => sett.Id);
            builder.HasIndex(sett => sett.Id);
            builder.Property(sett => sett.ProcentLearning).HasDefaultValue(0);
            builder.Property(sett => sett.Stage).HasDefaultValue(1);
            builder.Property(sett => sett.StagePoint).HasDefaultValue(6);
            builder.Property(sett => sett.StagePointBall).HasDefaultValue(0);
            builder.Property(sett => sett.Difficult).HasDefaultValue(10);

        }
    }
}