using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LeadManagementApi.Models.Enums;

namespace LeadManagementApi.Models;

[Table("Leads")]
public class Lead
{
  [Key]
  public int Id { get; set; }
  [Required]
  [Column(TypeName = "nvarchar(100)")]
  public string? CompanyName { get; set; }
  [Required]
  [Column(TypeName = "nvarchar(100)")]
  public string? PrimaryContactName { get; set; }
  [Required]
  [Column(TypeName = "nvarchar(100)")]
  public string? PrimaryContactEmail { get; set; }
  [Column(TypeName = "nvarchar(20)")]
  public string? PrimaryContactPhone { get; set; }
  [Column]
  public LeadStage LeadStage { get; set; }
  [Column]
  public DateTime? CreatedAt { get; set; }
  [Column]
  public DateTime? UpdatedAt { get; set; }
}