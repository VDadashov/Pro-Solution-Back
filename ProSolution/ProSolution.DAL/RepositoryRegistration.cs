using Microsoft.Extensions.DependencyInjection;
using ProSolution.DAL.Repositories.Abstractions.IAbourRepo;
using ProSolution.DAL.Repositories.Abstractions.IBadgeRepo;
using ProSolution.DAL.Repositories.Abstractions.Review;
using ProSolution.DAL.Repositories.Abstractions.Service;
using ProSolution.DAL.Repositories.Implementations;
using ProSolution.DAL.Repositories.Implementations.AboutRepo;
using ProSolution.DAL.Repositories.Implementations.BadgeRepo;
using ProSolution.DAL.Repositories.Implementations.Review;
using ProSolution.DAL.Repositories.Implementations.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.DAL
{
    
        public static class RepositoryRegistration
        {
            public static void AddRepositories(this IServiceCollection services)
            {
            // Register your repositories here
            services.AddScoped<IOurServiceReadRepository, OurSeriviceReadRepository>();
            services.AddScoped<IOurServiceWriteRepository, OurServiceWriteRepository>();
            services.AddScoped<IBadgeReadRepository, BadgeReadRepository>();
            services.AddScoped<IBadgeWriteRepository, BadgeWriteRepository>();
            services.AddScoped<IAboutReadRepository, AboutReadRepository>();
            services.AddScoped<IAboutWriteRepository, AboutWriteRepository>();
            services.AddScoped<IReviewReadRepository, ReviewReadRepository>();
            services.AddScoped<IReviewWriteRepository, ReviewWriteRepository>();


        }
    }
    
}