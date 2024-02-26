namespace LeadManagementApi.Data;

using Microsoft.EntityFrameworkCore;
using LeadManagementApi.Models;

public interface IContext : IDisposable
{
    DbSet<Lead> Leads { get; set; }
    Task<int> Add(Lead entity);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}