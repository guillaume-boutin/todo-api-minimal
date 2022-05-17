using Application.Repositories;
using Infrastructure.MySQL.Repositories;

namespace Infrastructure.ServiceProviders
{
    public static class RepositoriesServiceProvider
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITodoRepository, TodoRepository>();
        }
    }
}