using Microsoft.AspNetCore.Mvc;
using LeadManagementApi.Models;
using LeadManagementApi.Services;
using LeadManagementApi.Models.Enums;

namespace LeadManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeadsController : ControllerBase
{
    // declara a dependência do serviço de leads para ser injetada
    protected ILeadService _leadService;

    // injeta a dependência do serviço de leads no construtor
    public LeadsController(ILeadService leadService)
    {
        _leadService = leadService;
    }

    [HttpGet]
    public ActionResult<List<Lead>> GetAllLeads()
    {
        try
        {
            List<Lead> leads = _leadService.GetAllLeads();
            return Ok(leads);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message.ToString() });
        }
    }

    [HttpPost]
    public ActionResult CreateLead(LeadRequest request)
    {
        try
        {
            Lead lead = _leadService.CreateLead(request);
            return StatusCode(201, lead);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message.ToString() });
        }
    }

    [HttpPut("{id}")]
    public ActionResult UpdateLead(int id, [FromBody] LeadRequest request)
    {
        try
        {
            Lead lead = _leadService.UpdateLead(id, request);
            return Ok(lead);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message.ToString() });
        }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteLead(int id)
    {
        try
        {
            _leadService.DeleteLead(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message.ToString() });
        }
    }
}