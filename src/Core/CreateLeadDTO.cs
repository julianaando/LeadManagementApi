using LeadManagementApi.Models.Enums;

namespace LeadManagementApi.Models;

// dados de entrada do usuário para criar um lead
public class CreateLeadDTO
{
    public string? CompanyName { get; set; }
    public string? PrimaryContactName { get; set; }
    public string? PrimaryContactEmail { get; set; }
    public string? PrimaryContactPhone { get; set; }
}