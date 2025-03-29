using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using FizzBuzzDatabase.DTOs;
using FizzBuzzDatabase.Interfaces.IServices;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        // GET: api/game
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAllGames()
        {
            var games = await _gameService.GetAllGamesAsync();
            return Ok(games);
        }

        // GET: api/game/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> GetGame(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        // POST: api/game
        [HttpPost]
        public async Task<ActionResult<GameDto>> CreateGame([FromBody] CreateGameDTO createGameDTO)
        {
            var createdGame = await _gameService.CreateGameAsync(createGameDTO);
            return CreatedAtAction(nameof(GetGame), new { id = createdGame.Id }, createdGame);
        }

        // PUT: api/game/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, [FromBody] UpdateGameDTO updateGameDTO)
        {
            var updatedGame = await _gameService.UpdateGameAsync(id, updateGameDTO);
            if (updatedGame == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/game/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var result = await _gameService.DeleteGameAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
