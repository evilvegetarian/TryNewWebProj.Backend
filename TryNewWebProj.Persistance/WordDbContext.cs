using Microsoft.EntityFrameworkCore;
using TryNewWebProj.Application.Interfaces;
using TryNewWebProj.Domain;
using TryNewWebProj.Persistance.EntityTypeConfiguration;

namespace TryNewWebProj.Persistance
{
    public class WordDbContext : DbContext, IWordDbContext
    {
        public WordDbContext(DbContextOptions<WordDbContext> dbContext) : base(dbContext)
        {
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<SettingsWord> SettingsWords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new WordConfiguration());
            modelBuilder.ApplyConfiguration(new SettingsConfiguration());

            modelBuilder.Entity<Word>().HasOne(x => x.SettingsWord).WithOne(x => x.Word).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Word>().HasOne(x => x.Language).WithMany(y => y.Word).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SettingsWord>().HasOne(x => x.Word).WithOne(x => x.SettingsWord).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Language>().HasMany(x => x.Word).WithOne(x => x.Language).OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
    }
}
