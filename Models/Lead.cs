using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LeadManagementApi.Models.Enums;

namespace LeadManagementApi.Models;

[Table("Leads")]
public class Lead
{
  [Column("id")]
  public int Id { get; set; }
  [Required]
  [Column("company_name")]
  public string? CompanyName { get; set; }
  [Required]
  [Column("primary_contact_name")]
  public string? PrimaryContactName { get; set; }
  [Required]
  [Column("primary_contact_email")]
  public string? PrimaryContactEmail { get; set; }
  [Column("primary_contact_phone")]
  public string? PrimaryContactPhone { get; set; }
  [Column("lead_stage")]
  public LeadStage LeadStage { get; set; }
  [Column("created_at")]
  public DateTime? CreatedAt { get; set; }
  [Column("updated_at")]
  public DateTime? UpdatedAt { get; set; }
}