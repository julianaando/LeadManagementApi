namespace LeadManagementApi.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LeadManagementApi.Models;

public class Context(IConfiguration configuration) : DbContext, IContext
{
    private readonly IConfiguration _configuration = configuration;

    public DbSet<Lead> Leads { get; set; } = null!;


    public async Task<int> Add(Lead entity)
    {
        Leads.Add(entity);
        return await SaveChangesAsync();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro na configuração do DbContext: {ex.Message}");
            throw;
        }
    }

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
