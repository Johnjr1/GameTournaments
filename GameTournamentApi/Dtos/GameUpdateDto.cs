using System.ComponentModel.DataAnnotations;

public class GameUpdateDto
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = null!;

    public DateTime Time { get; set; }
    
    [Required]
    public int TournamentId { get; set; }
}