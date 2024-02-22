namespace LeadManagementApi.Services;

using System.Collections.Generic;
using LeadManagementApi.Models;
using LeadManagementApi.Models.Enums;
using Microsoft.AspNetCore.Mvc;

public class LeadService : ILeadService
{
    private int _nextId;
    private readonly List<Lead> _leadsList;
    private readonly LeadStage _leadStage;

    public LeadService()
    {
      _nextId = 1;
      _leadsList = new List<Lead>();
    }

    public Lead CreateLead(LeadRequest request)
    {
      if (request == null) throw new ArgumentNullException(nameof(request));

      var lead = request.CreateLead(_nextId++, LeadStage.CREATED);
      _leadsList.Add(lead);

      return lead;
    }

    public List<Lead> GetAllLeads()
    {
      return _leadsList;
    }


    public Lead UpdateLead(int id, LeadRequest request)
    {
      if (request == null) throw new ArgumentNullException(nameof(request));

      var lead = _leadsList.FirstOrDefault(x => x.Id == id) ?? throw new ArgumentException($"Lead with id {id} not found");
      var updatedLead = request.UpdateLead(lead);
      updatedLead.LeadStage = _leadStage;
      return updatedLead;
    }

    public void DeleteLead(int id)
    {
      var lead = _leadsList.Find(l => l.Id == id) ?? throw new ArgumentException($"Lead with id {id} not found");
      _leadsList.Remove(lead);
    }
}