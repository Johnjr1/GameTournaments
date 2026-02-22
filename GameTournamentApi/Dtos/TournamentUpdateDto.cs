using System.ComponentModel.DataAnnotations;

namespace GameTournamentApi.Dtos;

public class TournamentUpdateDto
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int MaxPlayers { get; set; }

    [FutureDate]
    public DateTime Date { get; set; }
}