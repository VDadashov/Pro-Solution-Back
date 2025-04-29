using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.BL.Services.InternalServices.Implementations;

namespace ProSolution.BL
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOurServiceService, OurServiceService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IBadgeService, BadgeService>();
            services.AddScoped<IAppInfoService, AppInfoService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddCloud(configuration);

        }
        private static void AddCloud(this IServiceCollection services, IConfiguration configuration)
        {
            var cloudName = configuration["Cloudinary:CloudName"];
            var cloudApiKey = configuration["Cloudinary:ApiKey"];
            var cloudApiSecret = configuration["Cloudinary:ApiSecret"];

            var account = new Account(cloudName, cloudApiKey, cloudApiSecret);
            var cloudinary = new Cloudinary(account);

            services.AddSingleton(cloudinary);
        }


    }
}
