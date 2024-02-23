using Microsoft.AspNetCore.Mvc;
using LeadManagementApi.Models;
using LeadManagementApi.Services;
using LeadManagementApi.Models.Enums;
using LeadManagementApi.Mappers;

namespace LeadManagementApi.Controllers;

[ApiController]
[Route("leads")]
public class LeadsController(ILeadService leadService) : ControllerBase
{
    // declara a dependência do serviço de leads para ser injetada
    protected ILeadService _leadService = leadService;

    [HttpGet]
    public async Task<ActionResult<List<LeadResponseDTO>>> GetAllLeads()
    {
        try
        {
            List<LeadResponseDTO> leads = await _leadService.GetAllLeadsAsync();
            return leads;
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message.ToString() });
        }
    }

    [HttpPost]
    public async Task<ActionResult<LeadResponseDTO>> CreateLead(CreateLeadDTO request)
    {
        try
        {
            LeadResponseDTO lead = await _leadService.CreateLeadAsync(request);
            return CreatedAtAction(nameof(GetLeadById), new { id = lead.Id }, lead);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message.ToString() });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeadResponseDTO>> GetLeadById(int id)
    {
        try
        {
            LeadResponseDTO lead = await _leadService.GetLeadByIdAsync(id);
            return lead;
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<LeadResponseDTO>> UpdateLead(int id, UpdateLeadDTO request)
    {
        try
        {
            LeadResponseDTO lead = await _leadService.UpdateLeadAsync(id, request);
            return lead;
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLead(int id)
    {
        try
        {
            await _leadService.DeleteLeadAsync(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("/test-database-connection")]
    public async Task<OkObjectResult> TestDatabaseConnection()
    {
        try
        {
            await _leadService.TestDatabaseConnection();
            return Ok(new { message = "Database connection test successful." });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error testing database connection: {ex.Message}");
            return (OkObjectResult)StatusCode(500, new { message = "Internal server error" });
        }
    }
}