using GameTournamentApi.Dtos;
using GameTournamentApi.Models;
using GameTournamentApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameTournamentApi.Controllers;

[ApiController]
[Route("api/games")]
public class GamesController : ControllerBase
{
    private readonly IGameService _service;

    public GamesController(IGameService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var games = await _service.GetAllAsync();
        return Ok(games);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var game = await _service.GetByIdAsync(id);
        if (game == null) return NotFound();
        return Ok(game);
    }

    [HttpPost]
    public async Task<IActionResult> Create(GameCreateDto dto)
    {
        var game = new Game
        {
            Title = dto.Title,
            Time = dto.Time,
            TournamentId = dto.TournamentId
        };

        var created = await _service.CreateAsync(game);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, GameUpdateDto dto)
    {
        var game = new Game
        {
            Title = dto.Title,
            Time = dto.Time,
            TournamentId = dto.TournamentId
        };

        var success = await _service.UpdateAsync(id, game);

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