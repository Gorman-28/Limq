using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Limq.Application;
public static class ApplicationRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ApplicationRegistration));
    }
}
