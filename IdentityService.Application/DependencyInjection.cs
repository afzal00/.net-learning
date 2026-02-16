
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {

            // Later:
            // services.AddMediatR(...)
            // services.AddValidatorsFromAssembly(...)

            return service;
        }
    }
}