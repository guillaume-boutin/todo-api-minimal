namespace Infrastructure.ServiceProviders
{
    public static class AppServiceProvider
    {
        public static void RegisterAppServices(this IServiceCollection services)
        {
            services.RegisterActions();
            services.RegisterRepositories();
        }
    }
}