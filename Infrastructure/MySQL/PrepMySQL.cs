using Microsoft.EntityFrameworkCore;

namespace Infrastructure.MySQL
{
    public static class PrepMySQL
    {
        public static void Migrate(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using(var serviceScope = app.ApplicationServices.CreateAsyncScope())
            {
                _WriteMigrations(serviceScope.ServiceProvider.GetService<MySQLContext>(), env);
            }
        }

        private static void _WriteMigrations(MySQLContext context, IWebHostEnvironment env)
        {
            try
            {
                context.Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not write migrations: {e.Message}");
            }
        }
    }
}