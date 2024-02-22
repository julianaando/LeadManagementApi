namespace LeadManagementApi.Services;
using LeadManagementApi.Models;
using LeadManagementApi.Models.Enums;

public interface ILeadService
{
  Lead CreateLead(LeadRequest request);
  List<Lead> GetAllLeads();
  Lead UpdateLead(int id, LeadRequest request);
  void DeleteLead(int id);
}