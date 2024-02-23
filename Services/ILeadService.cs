namespace LeadManagementApi.Services;
using LeadManagementApi.Models;
using LeadManagementApi.Models.Enums;

public interface ILeadService
{
    Task<LeadResponseDTO> CreateLeadAsync(CreateLeadDTO request);
    Task<List<LeadResponseDTO>> GetAllLeadsAsync();
    Task<LeadResponseDTO> UpdateLeadAsync(int id, UpdateLeadDTO request);
    Task DeleteLeadAsync(int id);
    Task TestDatabaseConnection();
    Task<LeadResponseDTO> GetLeadByIdAsync(int id);
}