using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.MySQL
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {}

        public DbSet<Todo> Todos { get; set; }
    }
}