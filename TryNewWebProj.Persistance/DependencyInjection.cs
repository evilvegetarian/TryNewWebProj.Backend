using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TryNewWebProj.Application.Interfaces;

namespace TryNewWebProj.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<WordDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IWordDbContext>(provider =>
                provider.GetService<WordDbContext>());
            return services;
        }
    }
}
