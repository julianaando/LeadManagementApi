using lead_management_api.Models.Enums;

namespace lead_management_api.Core;

public class LeadRequest
{
    public string? CompanyName { get; set; }
    public string? PrimaryContactName { get; set; }
    public string? PrimaryContactEmail { get; set; }
    public string? PrimaryContactPhone { get; set; }

    public Lead CreateLead(int id)
    {
        return new Lead
        {
            Id = id,
            CompanyName = CompanyName,
            PrimaryContactName = PrimaryContactName,
            PrimaryContactEmail = PrimaryContactEmail,
            PrimaryContactPhone = PrimaryContactPhone,
            // LeadStage = LeadStage.CREATED,
            CreatedAt = DateTime.Now,
        };
    }

    public Lead UpdateLead(Lead lead)
    {
        lead.CompanyName = CompanyName;
        lead.PrimaryContactName = PrimaryContactName;
        lead.PrimaryContactEmail = PrimaryContactEmail;
        lead.PrimaryContactPhone = PrimaryContactPhone;
        lead.UpdatedAt = DateTime.Now;
        return lead;
    }
}