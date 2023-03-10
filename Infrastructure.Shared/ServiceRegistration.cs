using Application.Interfaces;
using Domain.Settings;
using IMP.Application.Interfaces;
using IMP.Infrastructure.Shared.Services;
using Infrastructure.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.Configure<GoogleSettings>(_config.GetSection("Authentication").GetSection("Google"));
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IGoogleService, GoogleService>();
        }
    }
}