using lead_management_api.Models.Enums;

namespace lead_management_api.Core;

public class Lead
{
  public int Id { get; set; }
  public string? CompanyName { get; set; }
  public string? PrimaryContactName { get; set; }
  public string? PrimaryContactEmail { get; set; }
  public string? PrimaryContactPhone { get; set; }
  // public LeadStage LeadStage;
  public DateTime? CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
}