using Microsoft.AspNetCore.Mvc;
using lead_management_api.Core;

namespace lead_management_api.Controllers;

[ApiController]
[Route("leads")]
public class LeadController : ControllerBase
{
	private static readonly List<Lead> _leads = new();
    private static int _nextId = 1;

    [HttpGet]
    public ActionResult GetLeads()
    {
        return StatusCode(200, _leads);
    }

    [HttpPost]
    public ActionResult CreateLead(LeadRequest request)
    {
        var lead = request.CreateLead(_nextId++);
        _leads.Add(lead);

        return StatusCode(201, lead);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateLead(int id, LeadRequest request)
    {
        var lead = _leads.FirstOrDefault(c => c.Id == id);

        if (lead == null) return NotFound("Lead not found");

        var leadUpdated = request.UpdateLead(lead);
        return Ok(leadUpdated);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteLead(int id)
    {
        var leadDeleted = _leads.RemoveAll(c => c.Id == id);

        if (leadDeleted == 0) return NotFound("Lead not found");

        return NoContent();
    }
}