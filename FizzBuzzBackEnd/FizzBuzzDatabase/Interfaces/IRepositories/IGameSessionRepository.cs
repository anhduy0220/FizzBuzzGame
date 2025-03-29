using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Interfaces.IRepositories
{
    public interface IGameSessionRepository
    {
        Task<GameSession> GetGameSessionByIdAsync(int gameSessionId);
        Task<IEnumerable<GameSession>> GetAllGameSessionsAsync();
        Task<GameSession> AddGameSessionAsync(GameSession gameSession);
        Task<GameSession> UpdateGameSessionAsync(GameSession gameSession);
        Task<bool> DeleteGameSessionAsync(int gameSessionId);
    }
}