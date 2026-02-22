using GameTournamentApi.Dtos;
using GameTournamentApi.Models;
using GameTournamentApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameTournamentApi.Controllers;

[ApiController] 
[Route("api/tournaments")]
public class TournamentsController : ControllerBase
{
    private readonly ITournamentService _service;

    public TournamentsController(ITournamentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? search)
    {
        var tournaments = await _service.GetAllAsync(search);
        return Ok(tournaments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var tournament = await _service.GetByIdAsync(id);
        if (tournament == null) return NotFound();
        return Ok(tournament);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TournamentCreateDto dto)
    {
        var tournament = new Tournament
        {
            Title = dto.Title,
            Description = dto.Description,
            MaxPlayers = dto.MaxPlayers,
            Date = dto.Date
        };

        var created = await _service.CreateAsync(tournament);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TournamentUpdateDto dto)
    {
        var tournament = new Tournament
        {
            Title = dto.Title,
            Description = dto.Description,
            MaxPlayers = dto.MaxPlayers,
            Date = dto.Date
        };

        var success = await _service.UpdateAsync(id, tournament);
        if (!success) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
}