using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using FizzBuzzDatabase.DTOs;
using FizzBuzzDatabase.Interfaces.IServices;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameSessionController : ControllerBase
    {
        private readonly IGameSessionService _gameSessionService;

        public GameSessionController(IGameSessionService gameSessionService)
        {
            _gameSessionService = gameSessionService;
        }

        // POST: api/gamesession/start
        [HttpPost("start")]
        public async Task<ActionResult<InitialGameSessionQuestionDTO>> StartGameSession(
            [FromBody] InitialGameSessionDTO initialGameSessionDTO)
        {
            var session = await _gameSessionService.CreateAndStartGameSessionAsync(initialGameSessionDTO);
            return Ok(session);
        }

        // POST: api/gamesession/answer
        [HttpPost("answer")]
        public async Task<ActionResult<GameSessionResultAndNewQuestionDTO>> SubmitAnswer(
            [FromBody] GameSessionAnswerDTO gameSessionAnswerDTO)
        {
            var result = await _gameSessionService.HandleGameSessionAnswerAsync(gameSessionAnswerDTO);
            return Ok(result);
        }

        // POST: api/gamesession/end/5
        [HttpPost("end/{sessionId}")]
        public async Task<ActionResult<GameSessionResultDTO>> EndGameSession(int sessionId)
        {
            var result = await _gameSessionService.FinalizeGameSessionAsync(sessionId);
            return Ok(result);
        }

        // GET: api/gamesession/result/5
        [HttpGet("result/{sessionId}")]
        public async Task<ActionResult<GameSessionResultDTO>> GetGameSessionResult(int sessionId)
        {
            var result = await _gameSessionService.GetGameSessionResultAsync(sessionId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}