using MediatorPattern.Application;
using MediatorPattern.Repo;
using Microsoft.EntityFrameworkCore;

namespace MediatorPattern.API.AppStart
{
    public static class DIRegistrationExtensions
    {

        public static void AddDIRegistrations(this IServiceCollection services, IConfiguration configuration)
        {
            // Add your dependency injections here
            if(services != null)
            {
                // Register EFDbContext using the in-memory provider so it can be injected where needed.
                services.AddDbContext<EFDbContext>(options => options.UseInMemoryDatabase("MediatorPatternDb"));

                services.AddScoped<IDomainRepo, EFDomainRepo>();

                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ApplicationMarker)));
            }
        }
    }
}
