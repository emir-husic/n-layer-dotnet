using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Quiz.Data
{
    public static class DataConfiguration
    {
        public static IServiceCollection AddDataDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<QuizContext>(
        options =>
        {
            string V = configuration.GetConnectionString("Database");
            options.UseMySql(V, ServerVersion.AutoDetect(V));
        });

            return services;
        }
    }
}
