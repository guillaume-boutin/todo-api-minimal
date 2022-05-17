using Application.Actions;

namespace Infrastructure.ServiceProviders
{
    public static class ActionsServiceProvider
    {
        public static void RegisterActions(this IServiceCollection services)
        {
            services.AddScoped<ListTodos>();
            services.AddScoped<GetTodo>();
            services.AddScoped<CreateTodo>();
            services.AddScoped<UpdateTodo>();
        }
    }
}