using GameTournamentApi.Data;
using GameTournamentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentApi.Services;

public class TournamentService : ITournamentService
{
    private readonly ApplicationDbContext _context;

    public TournamentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Tournament>> GetAllAsync(string? search)
    {
        var query = _context.Tournaments
            .Include(t => t.Games)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(t => t.Title.Contains(search));
        }

        return await query.ToListAsync();
    }

    public async Task<Tournament?> GetByIdAsync(int id)
    {
        return await _context.Tournaments
            .Include(t => t.Games)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Tournament> CreateAsync(Tournament tournament)
    {
        _context.Tournaments.Add(tournament);
        await _context.SaveChangesAsync();
        return tournament;
    }

    public async Task<bool> UpdateAsync(int id, Tournament updated)
    {
        var existing = await _context.Tournaments.FindAsync(id);
        if (existing == null) return false;

        existing.Title = updated.Title;
        existing.Description = updated.Description;
        existing.MaxPlayers = updated.MaxPlayers;
        existing.Date = updated.Date;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var tournament = await _context.Tournaments.FindAsync(id);
        if (tournament == null) return false;

        _context.Tournaments.Remove(tournament);
        await _context.SaveChangesAsync();
        return true;
    }
}