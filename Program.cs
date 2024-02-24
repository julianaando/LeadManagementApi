using LeadManagementApi.Models;
using LeadManagementApi.Services;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using LeadManagementApi.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ILeadService, LeadService>();
builder.Services.AddControllers().AddNewtonsoftJson(options => 
{
    options.SerializerSettings.Converters.Add(new DateTimeConverter());
});

builder.Services.AddDbContext<Context>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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
        Description = "An ASP.NET Core Web API for my Ploomes debut :)",
        TermsOfService = null,
        Contact = null,
        License = null,
    });
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

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program {}