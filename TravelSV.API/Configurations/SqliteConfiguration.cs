using Microsoft.EntityFrameworkCore;
using TravelSV.API.Contexts;

namespace TravelSV.API.Configurations
{
    public static class SqliteConfiguration
    {
        public static IServiceCollection AddSqliteConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<TravelSvDbContext>(options => {
                options.UseSqlite("Data Source=c:\\db\\travelsv.api.db;");
                options.EnableSensitiveDataLogging();
            });

            return services;
        }
    }
}
