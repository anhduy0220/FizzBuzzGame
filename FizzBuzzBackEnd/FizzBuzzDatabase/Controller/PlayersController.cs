using FizzBuzzDatabase.Data;
using FizzBuzzDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly GameDB _context;

    public PlayerController(GameDB context)
    {
        _context = context;
    }

    // GET: api/Player
    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> GetPlayers()
    {
        var players = await _context.Player.ToListAsync();
        var result = players.Select(p => new
        {
            p.Id,
            p.Name,
            p.Email,
            p.HighScore
        });

        return Ok(result);
    }

    // NOTE: New endpoint added
    // GET: api/Player/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<object>> GetPlayerById(int id)
    {
        var player = await _context.Player.FindAsync(id);

        if (player == null)
        {
            return NotFound(new { error = "Player not found." });
        }

        return Ok(new
        {
            player.Id,
            player.Name,
            player.Email,
            player.HighScore
        });
    }

    // NOTE: New endpoint added
    // GET: api/Player/email/{email}
    [HttpGet("email/{email}")]
    public async Task<ActionResult<object>> GetPlayerByEmail(string email)
    {
        var player = await _context.Player.FirstOrDefaultAsync(p => p.Email == email);

        if (player == null)
        {
            return NotFound(new { error = "Player not found with the specified email." });
        }

        return Ok(new
        {
            player.Id,
            player.Name,
            player.Email,
            player.HighScore
        });
    }

    // POST: api/Player
    [HttpPost]
    public async Task<ActionResult> CreatePlayer([FromBody] Player newPlayer)
    {
        if (await _context.Player.AnyAsync(p => p.Email == newPlayer.Email))
        {
            return BadRequest(new { error = "Email already registered." });
        }

        _context.Player.Add(newPlayer);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPlayers), new { id = newPlayer.Id }, newPlayer);
    }

    // PUT: api/Player/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePlayer(int id, [FromBody] Player updatedPlayer)
    {
        var player = await _context.Player.FindAsync(id);
        if (player == null)
        {
            return NotFound(new { error = "Player not found." });
        }

        player.Name = updatedPlayer.Name;
        player.Email = updatedPlayer.Email;
        player.HighScore = updatedPlayer.HighScore;

        await _context.SaveChangesAsync();

        return Ok(new { message = "Player updated successfully." });
    }

    // DELETE: api/Player/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePlayer(int id)
    {
        var player = await _context.Player.FindAsync(id);

        if (player == null)
        {
            return NotFound(new { error = "Player not found." });
        }

        _context.Player.Remove(player);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Player deleted successfully." });
    }

    // NOTE: New endpoint added
    // GET: api/Player/{id}/sessions
    [HttpGet("{id}/sessions")]
    public async Task<ActionResult<IEnumerable<object>>> GetPlayerGameSessions(int id)
    {
        var player = await _context.Player
            .Include(p => p.GameSessions)
            .ThenInclude(gs => gs.Game)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (player == null)
        {
            return NotFound(new { error = "Player not found." });
        }

        var sessions = player.GameSessions.Select(gs => new
        {
            gs.Id,
            Game = new { gs.Game.Id, gs.Game.GameName },
            gs.Score,
            gs.StartTime,
            gs.EndTime
        });

        return Ok(sessions);
    }
}
