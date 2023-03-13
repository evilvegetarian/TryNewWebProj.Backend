using Microsoft.EntityFrameworkCore;
using TryNewWebProj.Domain;

namespace TryNewWebProj.Application.Interfaces
{
    public interface IWordDbContext
    {
        DbSet<Language> Languages { get; set; }
        DbSet<Word> Words { get; set; }
        DbSet<SettingsWord> SettingsWords { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}