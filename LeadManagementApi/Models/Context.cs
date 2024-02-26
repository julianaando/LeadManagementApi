namespace LeadManagementApi.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class Context(IConfiguration configuration) : DbContext
{
    private readonly IConfiguration _configuration = configuration;

    public DbSet<Lead> Leads { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
         try
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro na configuração do DbContext: {ex.Message}");
        }
    }
}
