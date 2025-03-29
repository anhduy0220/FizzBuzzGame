using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using FizzBuzzDatabase.DTOs;
using FizzBuzzDatabase.Interfaces.IServices;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameRuleController : ControllerBase
    {
        private readonly IGameRuleService _gameRuleService;

        public GameRuleController(IGameRuleService gameRuleService)
        {
            _gameRuleService = gameRuleService;
        }

        // GET: api/gamerule/game/5
        [HttpGet("game/{gameId}")]
        public async Task<ActionResult<IEnumerable<GameRuleDto>>> GetGameRulesByGameId(int gameId)
        {
            var rules = await _gameRuleService.GetGameRulesByGameIdAsync(gameId);
            return Ok(rules);
        }

        // GET: api/gamerule/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameRuleDto>> GetGameRule(int id)
        {
            var rule = await _gameRuleService.GetGameRuleByIdAsync(id);
            if (rule == null)
            {
                return NotFound();
            }
            return Ok(rule);
        }

        // POST: api/gamerule
        [HttpPost]
        public async Task<ActionResult<GameRuleDto>> CreateGameRule([FromBody] CreateGameRuleDTO createGameRuleDTO)
        {
            var createdRule = await _gameRuleService.CreateGameRuleAsync(createGameRuleDTO);
            return CreatedAtAction(nameof(GetGameRule), new { id = createdRule.Id }, createdRule);
        }

        // PUT: api/gamerule/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGameRule(int id, [FromBody] UpdateGameRuleDTO updateGameRuleDTO)
        {
            var updatedRule = await _gameRuleService.UpdateGameRuleAsync(id, updateGameRuleDTO);
            if (updatedRule == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/gamerule/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameRule(int id)
        {
            var result = await _gameRuleService.DeleteGameRuleAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
