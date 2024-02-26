namespace LeadManagementApi.Models;

public class CreateLeadDTO
{
    public string? CompanyName { get; set; }
    public string? PrimaryContactName { get; set; }
    public string? PrimaryContactEmail { get; set; }
    public string? PrimaryContactPhone { get; set; }
}