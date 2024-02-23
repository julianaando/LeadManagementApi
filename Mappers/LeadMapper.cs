using LeadManagementApi.Models;
using LeadManagementApi.Models.Enums;

namespace LeadManagementApi.Mappers
{
    public static class LeadMapper
    {
        public static Lead ToEntityFromCreateDTO(CreateLeadDTO dto)
        {
            return new Lead
            {
                CompanyName = dto.CompanyName,
                PrimaryContactName = dto.PrimaryContactName,
                PrimaryContactEmail = dto.PrimaryContactEmail,
                PrimaryContactPhone = dto.PrimaryContactPhone,
                LeadStage = LeadStage.CREATED,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
        }

        public static Lead ToEntityFromUpdateDTO(UpdateLeadDTO dto, Lead existingLead)
        {
            existingLead.CompanyName = dto.CompanyName;
            existingLead.PrimaryContactName = dto.PrimaryContactName;
            existingLead.PrimaryContactEmail = dto.PrimaryContactEmail;
            existingLead.PrimaryContactPhone = dto.PrimaryContactPhone;
            existingLead.LeadStage = dto.LeadStage;
            existingLead.UpdatedAt = DateTime.Now;

            return existingLead;
        }

        public static LeadResponseDTO MapToResponseDTO(Lead entity)
        {
            return new LeadResponseDTO
            {
                Id = entity.Id,
                CompanyName = entity.CompanyName,
                PrimaryContactName = entity.PrimaryContactName,
                PrimaryContactEmail = entity.PrimaryContactEmail,
                PrimaryContactPhone = entity.PrimaryContactPhone,
                LeadStage = entity.LeadStage,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
            };
        }
    }
}
