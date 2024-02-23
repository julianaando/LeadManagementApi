namespace LeadManagementApi.Services;

using System.Collections.Generic;
using LeadManagementApi.Models;
using LeadManagementApi.Models.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class LeadService : ILeadService
{
    private readonly Context _context;

    public LeadService(Context context)
    {
        _context = context;
    }


    public async Task<Lead> CreateLeadAsync(LeadRequest request)
    {
        try
        {
            var lead = request.CreateLead();
            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();
            return lead;
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"DbUpdateException: {ex.Message}");

            if (ex.InnerException is SqlException sqlException)
            {
                Console.WriteLine($"SqlException Number: {sqlException.Number}");
                Console.WriteLine($"SqlException State: {sqlException.State}");
                Console.WriteLine($"SqlException Message: {sqlException.Message}");
            }

            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while creating lead: {ex.Message}");
            throw;
        }
    }

    public async Task<List<Lead>> GetAllLeadsAsync()
    {
        return await _context.Leads.ToListAsync();
    }


    public async Task<Lead> UpdateLeadAsync(int id, LeadRequest request)
    {
        var lead = await _context.Leads.FindAsync(id) ?? throw new ArgumentException($"Lead with id {id} not found");
        var updatedLead = request.UpdateLead(lead);
        await _context.SaveChangesAsync();
        return updatedLead;
    }

    public async Task DeleteLeadAsync(int id)
    {
        var lead = await _context.Leads.FindAsync(id) ?? throw new ArgumentException($"Lead with id {id} not found");
        _context.Leads.Remove(lead);
        await _context.SaveChangesAsync();
    }

    public async Task TestDatabaseConnection()
    {
       var result = await _context.Database.CanConnectAsync();
       await _context.Database.ExecuteSqlRawAsync("SELECT 1");
    }
}