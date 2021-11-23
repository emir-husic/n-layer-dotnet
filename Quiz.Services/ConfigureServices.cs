using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Data;
using Quiz.Data.Interfaces;

namespace Quiz.Services
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDataDependencies(configuration);
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            return services;
        }
    }
}
