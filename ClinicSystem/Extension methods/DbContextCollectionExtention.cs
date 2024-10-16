using ClinicSystem.DataContext;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicSystem.Extension_methods
{
    public static class DbContextCollectionExtention
    {
        public static IServiceCollection AddDbContext(this IServiceCollection service)
            => service
                .AddScoped<AppDbContext>();
    }
}
