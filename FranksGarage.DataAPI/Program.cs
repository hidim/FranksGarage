using FranksGarage.DataAPI.Data;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;

var AllowCORSOrigins = "_allowCORSOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCORSOrigins,
                      corsBuilder =>
                      {
                          corsBuilder.WithOrigins(builder.Configuration.GetValue<string>("AllowedCORSOrigin").Split(','));
                      });
});

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddLogging(logging => logging.AddSerilog(
                new LoggerConfiguration()
                 .WriteTo.File(AppContext.BaseDirectory + "\\log\\log-.log", rollingInterval: RollingInterval.Day)
                 .MinimumLevel.Debug()
                 .Enrich.FromLogContext()
                 .CreateLogger()));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(
        SqliteConnectionPool.GetConnection(builder.Configuration)));
builder.Services.AddDataProtection()
                .PersistKeysToDbContext<ApplicationDbContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//// Migrations for App Context - Couldn't figured it out yet for .net core 6
//ApplicationDbContext dbcontext = app.Services.GetRequiredService<ApplicationDbContext>();
//dbcontext.Database.EnsureCreated();
//if (dbcontext.Database.GetPendingMigrations().Any())
//    dbcontext.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AllowCORSOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
