using Infrastructure.MySQL;
using Infrastructure.ServiceProviders;
using Microsoft.EntityFrameworkCore;
using UI.Web.Handlers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<MySQLContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// builder.Services.AddControllers();
builder.Services.RegisterAppServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseRouting();

app.RegisterHandlers();

PrepMySQL.Migrate(app, builder.Environment);

app.Run();