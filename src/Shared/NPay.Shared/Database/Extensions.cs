using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NPay.Shared.Database
{
    public static class Extensions
    {
        private const string SectionName = "postgres";
        
        internal static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PostgresOptions>(configuration.GetSection(SectionName));
            services.AddHostedService<DbContextAppInitializer>();

            return services;
        }

        public static IServiceCollection AddPostgres<T>(this IServiceCollection services) where T : DbContext
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var connectionString = configuration[$"{SectionName}:{nameof(PostgresOptions.ConnectionString)}"];
            services.AddDbContext<T>(x => x.UseNpgsql(connectionString));

            return services;
        }
    }
}