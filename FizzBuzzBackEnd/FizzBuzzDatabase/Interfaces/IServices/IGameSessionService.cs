using FizzBuzzDatabase.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzzDatabase.Interfaces.IServices
{
    public interface IGameSessionService
    {
        // Create and start a new game session
        public Task<InitialGameSessionQuestionDTO> CreateAndStartGameSessionAsync(InitialGameSessionDTO initialGameSessionDTO);

        // Handle the player's answer and return the result along with the next question
        public Task<GameSessionResultAndNewQuestionDTO> HandleGameSessionAnswerAsync(GameSessionAnswerDTO gameSessionAnswerDTO);

        // Finalize the game session (e.g., when time runs out)
        public Task<GameSessionResultDTO> FinalizeGameSessionAsync(int gameSessionId);

        // Get the final result of a game session
        public Task<GameSessionResultDTO> GetGameSessionResultAsync(int gameSessionId);
    }
}