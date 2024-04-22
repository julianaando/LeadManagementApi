namespace LeadManagementApi.Services;
using LeadManagementApi.Models;

public interface ILeadService
{
    Task<LeadResponseDTO> CreateLead(CreateLeadDTO request);
    Task<List<LeadResponseDTO>> GetAllLeads();
    Task<LeadResponseDTO> UpdateLead(int id, UpdateLeadDTO request);
    Task DeleteLead(int id);
    Task<LeadResponseDTO> GetLeadById(int id);
}