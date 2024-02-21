using LeadManagementApi.Models.Enums;

namespace LeadManagementApi.Models;

public class LeadRequest
{
    public string? CompanyName { get; }
    public string? PrimaryContactName { get; }
    public string? PrimaryContactEmail { get; }
    public string? PrimaryContactPhone { get; }

    // public Lead CreateLead(int id, LeadStage currentStage)
    // {
    //     return new Lead
    //     {
    //         Id = id,
    //         CompanyName = CompanyName,
    //         PrimaryContactName = PrimaryContactName,
    //         PrimaryContactEmail = PrimaryContactEmail,
    //         PrimaryContactPhone = PrimaryContactPhone,
    //         LeadStage = currentStage,
    //         CreatedAt = DateTime.Now,
    //         UpdatedAt = DateTime.Now
    //     };
    // }

    // public Lead UpdateLead(Lead lead)
    // {
    //     lead.CompanyName = CompanyName;
    //     lead.PrimaryContactName = PrimaryContactName;
    //     lead.PrimaryContactEmail = PrimaryContactEmail;
    //     lead.PrimaryContactPhone = PrimaryContactPhone;
    //     lead.LeadStage = lead.LeadStage;
    //     lead.UpdatedAt = DateTime.Now;
    //     return lead;
    // }
}