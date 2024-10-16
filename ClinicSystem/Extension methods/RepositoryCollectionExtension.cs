using ClinicSystem.Models;

using ClinicSystem.Repositories;
using ClinicSystem.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicSystem.Extention_methods
{
    public static class RepositoryCollectionExtension
    {
        public static IServiceCollection AddRepository(this IServiceCollection service)
            => service
                .AddScoped<IDoctorRepository, DoctorRepository>()
                .AddScoped<IClinicRepository, ClinicRepository>()
                .AddScoped<IReservationRepository,ReservationRepository>();

    }
}
