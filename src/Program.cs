using LeadManagementApi.Models;
using LeadManagementApi.Services;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using LeadManagementApi.Caching;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddScoped<ICachingService, CachingService>();

Console.WriteLine("teste: " + builder.Configuration.GetConnectionString("RedisConnection"));
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
    options.InstanceName = "LeadManagementApiCache";
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo 
    {
        Version = "v1",
        Title = "Lead Management API",
        Description = "A .NET API for my Ploomes debut :)",
    });

    options.CustomSchemaIds(type => type.ToString());
});

var app = builder.Build();

await using var scope = app.Services.CreateAsyncScope();
using var db = scope.ServiceProvider.GetService<Context>();
if (db != null)
{
    await db.Database.MigrateAsync();
}

app.UseSwagger();
app.UseSwaggerUI(options => 
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
}

);

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program {}