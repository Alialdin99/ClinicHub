using ClinicSystem.Services;
using ClinicSystem.Services.ClinicSystem.Services;

using Microsoft.AspNetCore.Authentication;

namespace ClinicSystem.Extension_methods
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddService(this IServiceCollection service)
            => service
                .AddScoped<ClinicService>()
                .AddScoped<DoctorService>()
                .AddScoped<ReservationService>();

    }
}
