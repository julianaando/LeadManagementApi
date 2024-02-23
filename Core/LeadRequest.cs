using LeadManagementApi.Models.Enums;

namespace LeadManagementApi.Models;

public class LeadRequest
{
    public string? CompanyName { get; set; }
    public string? PrimaryContactName { get; set; }
    public string? PrimaryContactEmail { get; set; }
    public string? PrimaryContactPhone { get; set; }

    public Lead CreateLead()
    {
        return new Lead
        {
            CompanyName = CompanyName,
            PrimaryContactName = PrimaryContactName,
            PrimaryContactEmail = PrimaryContactEmail,
            PrimaryContactPhone = PrimaryContactPhone,
            LeadStage = LeadStage.CREATED,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }

    public Lead UpdateLead(Lead lead)
    {
        lead.CompanyName = CompanyName;
        lead.PrimaryContactName = PrimaryContactName;
        lead.PrimaryContactEmail = PrimaryContactEmail;
        lead.PrimaryContactPhone = PrimaryContactPhone;
        lead.LeadStage = lead.LeadStage;
        lead.UpdatedAt = DateTime.Now;
        return lead;
    }
}