namespace LeadManagementApi.Services;

using System.Collections.Generic;
using LeadManagementApi.Mappers;
using LeadManagementApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

public class LeadService(Context context) : ILeadService
{
    private readonly Context _context = context;

    public async Task<LeadResponseDTO> CreateLeadAsync(CreateLeadDTO request)
    {
        try
        {
            var leadEntity = LeadMapper.ToEntityFromCreateDTO(request);
            _context.Leads.Add(leadEntity);
            await _context.SaveChangesAsync();
            return LeadMapper.MapToResponseDTO(leadEntity);
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

    public async Task<List<LeadResponseDTO>> GetAllLeadsAsync()
    {
        try
        {
            var leadEntities = await _context.Leads.ToListAsync();
            return leadEntities.Select(LeadMapper.MapToResponseDTO).ToList();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"DbUpdateException: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while retrieving leads: {ex.Message}");
            throw;
        }
    }


    public async Task<LeadResponseDTO> UpdateLeadAsync(int id, UpdateLeadDTO request)
    {
        try
        {
            var leadEntity = await _context.Leads.FindAsync(id) ?? throw new ArgumentException($"Lead with id {id} not found");
            leadEntity = LeadMapper.ToEntityFromUpdateDTO(request, leadEntity);
            await _context.SaveChangesAsync();
            return LeadMapper.MapToResponseDTO(leadEntity);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            Console.WriteLine($"DbUpdateConcurrencyException: {ex.Message}");
            throw;
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"DbUpdateException: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while updating lead: {ex.Message}");
            throw;
        }
    }

    public async Task DeleteLeadAsync(int id)
    {
        try
        {
            var lead = await _context.Leads.FindAsync(id) ?? throw new ArgumentException($"Lead with id {id} not found");
            _context.Leads.Remove(lead);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"DbUpdateException: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while deleting lead: {ex.Message}");
            throw;
        }
    }

    public async Task TestDatabaseConnection()
    {
       var result = await _context.Database.CanConnectAsync();
       await _context.Database.ExecuteSqlRawAsync("SELECT 1");
    }

    public Task<LeadResponseDTO> GetLeadByIdAsync(int id)
    {
        try
        {
            var leadEntity = _context.Leads.Find(id) ?? throw new ArgumentException($"Lead with id {id} not found");
            return Task.FromResult(LeadMapper.MapToResponseDTO(leadEntity));
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"DbUpdateException: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while retrieving lead: {ex.Message}");
            throw;
        }
    }
}