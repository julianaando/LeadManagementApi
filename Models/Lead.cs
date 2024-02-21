using System.ComponentModel.DataAnnotations;
using LeadManagementApi.Models.Enums;

namespace LeadManagementApi.Models;

public class Lead
{
  public int Id { get; set; }
  [Required]
  public string? CompanyName { get; set; }
  [Required]
  public string? PrimaryContactName { get; set; }
  [Required]
  public string? PrimaryContactEmail { get; set; }
  public string? PrimaryContactPhone { get; set; }
  public LeadStage LeadStage { get; set; }
  public DateTime? CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
}