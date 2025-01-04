using MagicVilla_Api_Udemy;
using Microsoft.EntityFrameworkCore;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// This dependency injection for logger information.
Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo
    .File("api/villaLogs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();

// Inject DB context and connection string , This will pass connection string to DB context.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
