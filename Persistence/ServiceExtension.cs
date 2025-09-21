using Application.Repositories;
using Application.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Common;
using Persistence.Context;
using Persistence.Repositories;
using Domain.Entities;



namespace Persistence
{
    public static class ServiceExtension
    {

            public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
            {
                // Add DbContext with proper SSL configuration and retry logic
                services.AddDbContext<OffersDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection") ??
                                           "Data Source=.;Initial Catalog=OffersDb;Integrated Security=True;TrustServerCertificate=True",
                        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
                            maxRetryCount: 3,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null)
                    ));

                // Add Specific Repositories (for backward compatibility and specific methods)
                services.AddScoped<IOfferRepository, OfferRepository>();
                services.AddScoped<ICategoryRepository, CategoryRepository>();
                services.AddScoped<IDependentRepository, DependentRepository>();
                services.AddScoped<IEmployeeRepository, EmployeeRepository>();
                services.AddScoped<IOfferUsageRepository, OfferUsageRepository>();
                services.AddScoped<IOfferShareRepository, OfferShareRepository>();

                // Add Unit of Work
                services.AddScoped<IUnitOfWork, Persistence.Common.UnitOfWork>();
            }
        }

       /* public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext
            services.AddDbContext<OffersDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection") ??
                     "Data Source=LABDOU\\LABEBA;Initial Catalog=OffersDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
                ));

            // Add Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            // Add Generic Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Add Specific Repositories (for backward compatibility and specific methods)
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IOfferShareRepository, OfferShareRepository>();

            // Add Services
            services.AddScoped<IOfferService, OfferService>();
           // services.AddScoped<IOfferShareService, OfferShareService>();

            return services;
        }
    }*/
}
