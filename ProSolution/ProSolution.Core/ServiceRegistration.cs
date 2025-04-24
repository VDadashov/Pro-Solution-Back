using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.BL.Services.InternalServices.Implementations;
using ProSolution.BL.Services.ExternalServices;
using ProSolution.BL.Settings;
using Microsoft.Extensions.Options;
using ProSolution.BL.Settings;

namespace ProSolution.BL
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOurServiceService, OurServiceService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IBadgeService, BadgeService>();
            services.AddScoped<IAppInfoService, AppInfoService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IReviewService, ReviewService>();
        }

    }
}
