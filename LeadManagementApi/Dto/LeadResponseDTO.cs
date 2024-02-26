using LeadManagementApi.Models.Enums;
using Newtonsoft.Json;

namespace LeadManagementApi.Models;

public class LeadResponseDTO
{
    public int Id { get; set; }
    public string? CompanyName { get; set; }
    public string? PrimaryContactName { get; set; }
    public string? PrimaryContactEmail { get; set; }
    public string? PrimaryContactPhone { get; set; }
    public LeadStage LeadStage { get; set; }

    // [JsonConverter(typeof(DateTimeConverter))]
    public DateTime CreatedAt { get; set; }

    // [JsonConverter(typeof(DateTimeConverter))]
    public DateTime UpdatedAt { get; set; }
}