namespace LeadManagementApi.Services;

using System.Collections.Generic;
using LeadManagementApi.Caching;
using LeadManagementApi.Mappers;
using LeadManagementApi.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using LeadManagementApi.Models;

public class LeadService(Context context, ICachingService cache) : ILeadService
{
    private readonly Context _context = context;
    private readonly ICachingService _cache = cache;

    public async Task<LeadResponseDTO> CreateLead(CreateLeadDTO request)
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

    public async Task<List<LeadResponseDTO>> GetAllLeads()
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

    public async Task<LeadResponseDTO> UpdateLead(int id, UpdateLeadDTO request)
    {
        try
        {
            var leadEntity = await _context.Leads.FindAsync(id) ?? throw new ArgumentException($"Lead with id {id} not found");
            leadEntity = LeadMapper.ToEntityFromUpdateDTO(request, leadEntity);
            await _context.SaveChangesAsync();
            await _cache.InvalidateAsync("leads", id);
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

    public async Task DeleteLead(int id)
    {
        try
        {
            var lead = await _context.Leads.FindAsync(id) ?? throw new ArgumentException($"Lead with id {id} not found");
            _context.Leads.Remove(lead);
            await _context.SaveChangesAsync();
            await _cache.InvalidateAsync("leads", id);
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

    public async Task<LeadResponseDTO> GetLeadById(int id)
    {
        var cacheLead = await _cache.GetAsync("leads", id);
        
        if (cacheLead != null)
        {
            var cachedLeadEntity = JsonConvert.DeserializeObject<LeadResponseDTO>(cacheLead);
            Console.WriteLine("Loaded from cache");
            if (cachedLeadEntity != null) {
                return cachedLeadEntity;
            }
        }

        var leadEntityFromDatabase = _context.Leads.Find(id) ?? throw new ArgumentException($"Lead with id {id} not found");
        var leadEntity = LeadMapper.MapToResponseDTO(leadEntityFromDatabase);

        await _cache.SetAsync("leads", id, JsonConvert.SerializeObject(leadEntity));

        Console.WriteLine("Loaded from database");
        return leadEntity;
    }
}