using LeadManagementApi.Models.Enums;

namespace LeadManagementApi.Models;

public class UpdateLeadDTO
{
    public string? CompanyName { get; set; }
    public string? PrimaryContactName { get; set; }
    public string? PrimaryContactEmail { get; set; }
    public string? PrimaryContactPhone { get; set; }
    public LeadStage LeadStage { get; set; }
}