﻿using Microsoft.Extensions.DependencyInjection;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.BL.Services.InternalServices.Implementations;
<<<<<<< HEAD
using ProSolution.BL.Services.ExternalServices;
using ProSolution.BL.Settings;
using Microsoft.Extensions.Options;
using ProSolution.BL.Settings;
using ProSolution.Business.Services.InternalServices.Abstractions;
using ProSolution.DAL.Repositories.Abstractions.ISeoRepo;
using ProSolution.DAL.Repositories.Implementations.SeoRepo;
=======
>>>>>>> 36f3da087d90d09650f69a1bf9808c7d8ff3e131

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
            // SEO Meta
          
            services.AddScoped<ISeoMetaService, SeoMetaService>();

            // SEO Url
           
            services.AddScoped<ISeoUrlService, SeoUrlService>();

            // SEO Data (AnchorText, AltText и т.д.)
          
            services.AddScoped<ISeoService, SEOService>();

        }

    }
}
