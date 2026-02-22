using Microsoft.EntityFrameworkCore;
using GameTournamentApi.Models;

namespace GameTournamentApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Tournament> Tournaments => Set<Tournament>();
    
    public DbSet<Game> Games => Set<Game>();
}