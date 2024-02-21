using LeadManagementApi.Models.Enums;

namespace LeadManagementApi.Models;

public class LeadResponse
{
    public int Id { get; set; }
    public string? CompanyName { get; set; }
    public string? PrimaryContactName { get; set; }
    public string? PrimaryContactEmail { get; set; }
    public string? PrimaryContactPhone { get; set; }
    public LeadStage LeadStage { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}