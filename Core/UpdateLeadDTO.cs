using LeadManagementApi.Models.Enums;

namespace LeadManagementApi.Models;

// dados de entrada do usuário para atualizar um lead
public class UpdateLeadDTO
{
    public string? CompanyName { get; set; }
    public string? PrimaryContactName { get; set; }
    public string? PrimaryContactEmail { get; set; }
    public string? PrimaryContactPhone { get; set; }
    public LeadStage LeadStage { get; set; }
}