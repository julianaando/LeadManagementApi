namespace LeadManagementApi.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LeadManagementApi.Models;
    using LeadManagementApi.Models.Enums;
    using LeadManagementApi.Mappers;
    using LeadManagementApi.Services;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class ServiceUnitTests
    {
        [Fact]
        public void Testing_Mapper_MapToResponseDTO()
        {
            var leadEntities = new List<Lead>
            {
                new Lead
                {
                    Id = 1,
                    CompanyName = "Company 1",
                    PrimaryContactName = "John Doe",
                    PrimaryContactEmail = "johndoe@teste.com",
                    PrimaryContactPhone = "1234567890",
                    LeadStage = LeadStage.CREATED,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
            };

            var result = LeadMapper.MapToResponseDTO(leadEntities[0]);

            Assert.NotNull(result);
            Assert.IsType<LeadResponseDTO>(result);
            Assert.Equal(leadEntities[0].CompanyName, result.CompanyName);
            Assert.Equal(leadEntities[0].PrimaryContactName, result.PrimaryContactName);
            Assert.Equal(leadEntities[0].PrimaryContactEmail, result.PrimaryContactEmail);
            Assert.Equal(leadEntities[0].PrimaryContactPhone, result.PrimaryContactPhone);
            Assert.Equal(leadEntities[0].LeadStage, result.LeadStage);
            Assert.Equal(leadEntities[0].CreatedAt, result.CreatedAt);
            Assert.Equal(leadEntities[0].UpdatedAt, result.UpdatedAt);
        }

        [Fact]
        public void Testing_Mapper_ToEntityFromCreateDTO()
        {
            var request = new CreateLeadDTO
            {
                CompanyName = "Company 1",
                PrimaryContactName = "John Doe",
                PrimaryContactEmail = "johndoe@test.com",
                PrimaryContactPhone = "1234567890",
            };

            var result = LeadMapper.ToEntityFromCreateDTO(request);

            Assert.NotNull(result);
            Assert.IsType<Lead>(result);
            Assert.Equal(request.CompanyName, result.CompanyName);
            Assert.Equal(request.PrimaryContactName, result.PrimaryContactName);
            Assert.Equal(request.PrimaryContactEmail, result.PrimaryContactEmail);
            Assert.Equal(request.PrimaryContactPhone, result.PrimaryContactPhone);
        }

        [Fact]
        public void Testing_Mapper_ToEntityFromUpdateDTO()
        {
            var leadEntity = new Lead
            {
                Id = 1,
                CompanyName = "Company 2",
                PrimaryContactName = "Jane Doe",
                PrimaryContactEmail = "janedoe@test.com",
                PrimaryContactPhone = "0987654321",
                LeadStage = LeadStage.CREATED,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            var request = new UpdateLeadDTO
            {
                CompanyName = "Company 2",
                PrimaryContactName = "Jane Doe",
                PrimaryContactEmail = "janedoe@test.com",
                PrimaryContactPhone = "0987654321",
                LeadStage = LeadStage.PROSPECTING,
            };

            var initialLeadStage = leadEntity.LeadStage;

            var result = LeadMapper.ToEntityFromUpdateDTO(request, leadEntity);

            Assert.NotNull(result);
            Assert.IsType<Lead>(result);
            Assert.Equal(request.CompanyName, result.CompanyName);
            Assert.NotEqual(initialLeadStage, result.LeadStage);
            Assert.Equal(request.LeadStage, result.LeadStage);
        }
    }
}
