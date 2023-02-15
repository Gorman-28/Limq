using Limq.Persistence.LimqDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Limq.Persistence;
public static class PersistenceRegistration
{
    private const string ConnectionString = "DbConnection";

    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionString);
        services.AddDbContext<LimqDbContext>(options =>
            options.UseSqlServer(connectionString), ServiceLifetime.Singleton, ServiceLifetime.Singleton);
    }
}
