using Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyInjection
{
    public static class CoreServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PortfolioDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:PortfolioConnectionString"]);
            }, ServiceLifetime.Transient); 
              
            return services;
        }
    }
}
