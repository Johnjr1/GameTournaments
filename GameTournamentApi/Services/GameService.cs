using GameTournamentApi.Data;
using GameTournamentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentApi.Services;

public class GameService : IGameService
{
    private readonly ApplicationDbContext _context;

    public GameService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Game>> GetAllAsync()
    {
        return await _context.Games
            .Include(g => g.Tournament)
            .ToListAsync();
    }

    public async Task<Game?> GetByIdAsync(int id)
    {
        return await _context.Games
            .Include(g => g.Tournament)
            .FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<Game> CreateAsync(Game game)
    {
        var tournamentExists = await _context.Tournaments
            .AnyAsync(t => t.Id == game.TournamentId);

        if (!tournamentExists)
            throw new Exception("Tournament does not exist");

        _context.Games.Add(game);
        await _context.SaveChangesAsync();

        return game;
    }

    public async Task<bool> UpdateAsync(int id, Game updatedGame)
    {
        var existing = await _context.Games.FindAsync(id);
        if (existing == null) return false;

        var tournamentExists = await _context.Tournaments
            .AnyAsync(t => t.Id == updatedGame.TournamentId);

        if (!tournamentExists)
            throw new Exception("Tournament does not exist");

        existing.Title = updatedGame.Title;
        existing.Time = updatedGame.Time;
        existing.TournamentId = updatedGame.TournamentId;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null) return false;

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
        return true;
    }
}