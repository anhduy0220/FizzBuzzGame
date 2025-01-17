using FizzBuzzDatabase.Data;
using FizzBuzzDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class GameRulesController : ControllerBase
{
    private readonly GameDB _context;

    public GameRulesController(GameDB context)
    {
        _context = context;
    }

    // GET: api/GameRules
    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> GetGameRules()
    {
        var rules = await _context.GameRule
            .Include(r => r.Game)
            .ToListAsync();

        var result = rules.Select(r => new
        {
            r.Id,
            r.Divisor,
            r.Word,
            Game = new { r.Game.Id, r.Game.GameName }
        });

        return Ok(result);
    }

    // NOTE: New endpoint added
    // GET: api/GameRules/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<object>> GetGameRuleById(int id)
    {
        var rule = await _context.GameRule
            .Include(r => r.Game)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (rule == null)
        {
            return NotFound(new { error = "Rule not found." });
        }

        return Ok(new
        {
            rule.Id,
            rule.Divisor,
            rule.Word,
            Game = new { rule.Game.Id, rule.Game.GameName }
        });
    }

    // NOTE: New endpoint added
    // GET: api/GameRules/game/{gameId}
    [HttpGet("game/{gameId}")]
    public async Task<ActionResult<IEnumerable<object>>> GetRulesByGameId(int gameId)
    {
        var game = await _context.Game.Include(g => g.Rules).FirstOrDefaultAsync(g => g.Id == gameId);

        if (game == null)
        {
            return NotFound(new { error = "Game not found." });
        }

        var rules = game.Rules.Select(r => new
        {
            r.Id,
            r.Divisor,
            r.Word
        });

        return Ok(rules);
    }

    // POST: api/GameRules
    [HttpPost]
    public async Task<ActionResult> CreateRule([FromBody] GameRule newRule)
    {
        var game = await _context.Game.FindAsync(newRule.GameId);

        if (game == null)
        {
            return BadRequest(new { error = "Invalid Game ID." });
        }

        _context.GameRule.Add(newRule);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGameRules), new { id = newRule.Id }, newRule);
    }

    // NOTE: New endpoint added
    // PUT: api/GameRules/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateRule(int id, [FromBody] GameRule updatedRule)
    {
        if (id != updatedRule.Id)
        {
            return BadRequest(new { error = "ID mismatch." });
        }

        var existingRule = await _context.GameRule.FindAsync(id);

        if (existingRule == null)
        {
            return NotFound(new { error = "Rule not found." });
        }

        existingRule.Divisor = updatedRule.Divisor;
        existingRule.Word = updatedRule.Word;
        existingRule.GameId = updatedRule.GameId;

        _context.Entry(existingRule).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/GameRules/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRule(int id)
    {
        var rule = await _context.GameRule.FindAsync(id);

        if (rule == null)
        {
            return NotFound(new { error = "Rule not found." });
        }

        _context.GameRule.Remove(rule);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Rule deleted successfully." });
    }
}
