using Microsoft.AspNetCore.Mvc;
using LeadManagementApi.Models;
using LeadManagementApi.Services;

namespace LeadManagementApi.Controllers;

[ApiController]
[Route("leads")]
public class LeadsController(ILeadService leadService) : ControllerBase
{
    protected ILeadService _leadService = leadService;

    [HttpGet]
    public async Task<ActionResult<List<LeadResponseDTO>>> GetAllLeads()
    {
        try
        {
            List<LeadResponseDTO> leads = await _leadService.GetAllLeads();
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
            LeadResponseDTO lead = await _leadService.CreateLead(request);
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
            LeadResponseDTO lead = await _leadService.GetLeadById(id);
            return lead;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex);
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<LeadResponseDTO>> UpdateLead(int id, UpdateLeadDTO request)
    {
        try
        {
            LeadResponseDTO lead = await _leadService.UpdateLead(id, request);
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
            await _leadService.DeleteLead(id);
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
}