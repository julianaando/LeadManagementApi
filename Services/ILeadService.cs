namespace LeadManagementApi.Services;
using LeadManagementApi.Models;
using LeadManagementApi.Models.Enums;

public interface ILeadService
{
    Task<Lead> CreateLeadAsync(LeadRequest request);
    Task<List<Lead>> GetAllLeadsAsync();
    Task<Lead> UpdateLeadAsync(int id, LeadRequest request);
    Task DeleteLeadAsync(int id);
    Task TestDatabaseConnection();
}