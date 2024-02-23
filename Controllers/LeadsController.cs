using Microsoft.AspNetCore.Mvc;
using LeadManagementApi.Models;
using LeadManagementApi.Services;
using LeadManagementApi.Models.Enums;

namespace LeadManagementApi.Controllers;

[ApiController]
[Route("leads")]
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
    public async Task<ActionResult<List<Lead>>> GetAllLeads()
    {
        try
        {
            List<Lead> leads = await _leadService.GetAllLeadsAsync();
            return Ok(leads);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message.ToString() });
        }
    }

    [HttpPost]
    public async Task<ActionResult<Lead>> CreateLead(LeadRequest request)
    {
        try
        {
            Lead lead = await _leadService.CreateLeadAsync(request);
            return Ok(lead);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message.ToString() });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Lead>> UpdateLead(int id, LeadRequest request)
    {
        try
        {
            Lead lead = await _leadService.UpdateLeadAsync(id, request);
            return Ok(lead);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message.ToString() });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLead(int id)
    {
        try
        {
            await _leadService.DeleteLeadAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message.ToString() });
        }
    }

    [HttpGet("/test-database-connection")]
    public async Task TestDatabaseConnection()
    {
        try
        {
            await _leadService.TestDatabaseConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao testar a conexão com o banco de dados: {ex.Message}");
        }
    }
}