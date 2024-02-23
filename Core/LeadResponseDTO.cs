using LeadManagementApi.Models.Enums;
using LeadManagementApi.Utils;
using Newtonsoft.Json;

namespace LeadManagementApi.Models;

// dados que serão retornados ao usuário após criar um lead
public class LeadResponseDTO
{
    public int Id { get; set; }
    public string? CompanyName { get; set; }
    public string? PrimaryContactName { get; set; }
    public string? PrimaryContactEmail { get; set; }
    public string? PrimaryContactPhone { get; set; }

    [JsonConverter(typeof(EnumConverter))]
    public LeadStage LeadStage { get; set; }

    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime CreatedAt { get; set; }

    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime UpdatedAt { get; set; }
}