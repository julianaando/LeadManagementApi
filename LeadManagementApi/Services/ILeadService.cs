namespace LeadManagementApi.Services;
using LeadManagementApi.Models;

public interface ILeadService
{
    Task<LeadResponseDTO> CreateLeadAsync(CreateLeadDTO request);
    Task<List<LeadResponseDTO>> GetAllLeadsAsync();
    Task<LeadResponseDTO> UpdateLeadAsync(int id, UpdateLeadDTO request);
    Task DeleteLeadAsync(int id);
    Task<LeadResponseDTO> GetLeadByIdAsync(int id);
}