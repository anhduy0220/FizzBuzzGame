using FizzBuzzDatabase.Data;
using FizzBuzzDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class GameSessionsController : ControllerBase
{
    private readonly GameDB _context;

    public GameSessionsController(GameDB context)
    {
        _context = context;
    }

    // GET: api/GameSessions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> GetGameSessions()
    {
        var sessions = await _context.GameSession
            .Include(gs => gs.Player)
            .Include(gs => gs.Game)
            .ToListAsync();

        var result = sessions.Select(gs => new
        {
            gs.Id,
            Player = new { gs.Player.Id, gs.Player.Name, gs.Player.Email },
            Game = new { gs.Game.Id, gs.Game.GameName },
            gs.Score,
            gs.StartTime,
            gs.EndTime
        });

        return Ok(result);
    }

    // NOTE: New endpoint added
    // GET: api/GameSessions/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<object>> GetGameSessionById(int id)
    {
        var session = await _context.GameSession
            .Include(gs => gs.Player)
            .Include(gs => gs.Game)
            .FirstOrDefaultAsync(gs => gs.Id == id);

        if (session == null)
        {
            return NotFound(new { error = "Game session not found." });
        }

        return Ok(new
        {
            session.Id,
            Player = new { session.Player.Id, session.Player.Name, session.Player.Email },
            Game = new { session.Game.Id, session.Game.GameName },
            session.Score,
            session.StartTime,
            session.EndTime
        });
    }

    // NOTE: New endpoint added
    // GET: api/GameSessions/player/{playerId}
    [HttpGet("player/{playerId}")]
    public async Task<ActionResult<IEnumerable<object>>> GetSessionsByPlayerId(int playerId)
    {
        var sessions = await _context.GameSession
            .Where(gs => gs.PlayerId == playerId)
            .Include(gs => gs.Game)
            .ToListAsync();

        if (!sessions.Any())
        {
            return NotFound(new { error = "No sessions found for the specified player." });
        }

        var result = sessions.Select(gs => new
        {
            gs.Id,
            gs.Score,
            gs.StartTime,
            gs.EndTime,
            Game = new { gs.Game.Id, gs.Game.GameName }
        });

        return Ok(result);
    }

    // NOTE: New endpoint added
    // GET: api/GameSessions/game/{gameId}
    [HttpGet("game/{gameId}")]
    public async Task<ActionResult<IEnumerable<object>>> GetSessionsByGameId(int gameId)
    {
        var sessions = await _context.GameSession
            .Where(gs => gs.GameId == gameId)
            .Include(gs => gs.Player)
            .ToListAsync();

        if (!sessions.Any())
        {
            return NotFound(new { error = "No sessions found for the specified game." });
        }

        var result = sessions.Select(gs => new
        {
            gs.Id,
            Player = new { gs.Player.Id, gs.Player.Name },
            gs.Score,
            gs.StartTime,
            gs.EndTime
        });

        return Ok(result);
    }

    // POST: api/GameSessions
    [HttpPost]
    public async Task<ActionResult> CreateGameSession([FromBody] GameSession newSession)
    {
        var player = await _context.Player.FindAsync(newSession.PlayerId);
        var game = await _context.Game.FindAsync(newSession.GameId);

        if (player == null || game == null)
        {
            return BadRequest(new { error = "Invalid Player or Game ID." });
        }

        _context.GameSession.Add(newSession);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGameSessions), new { id = newSession.Id }, newSession);
    }

    // PUT: api/GameSessions/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateGameSession(int id, [FromBody] GameSession updatedSession)
    {
        var session = await _context.GameSession.FindAsync(id);

        if (session == null)
        {
            return NotFound(new { error = "Game session not found." });
        }

        session.Score = updatedSession.Score;
        session.StartTime = updatedSession.StartTime;
        session.EndTime = updatedSession.EndTime;

        await _context.SaveChangesAsync();
        return Ok(new { message = "Game session updated successfully." });
    }

    // DELETE: api/GameSessions/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteGameSession(int id)
    {
        var session = await _context.GameSession.FindAsync(id);

        if (session == null)
        {
            return NotFound(new { error = "Game session not found." });
        }

        _context.GameSession.Remove(session);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Game session deleted successfully." });
    }
}
