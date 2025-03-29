using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FizzBuzzDatabase.Data;
using FizzBuzzDatabase.Interfaces.IRepositories;
using FizzBuzzDatabase.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzzDatabase.Server.Repositories
{
    public class GameSessionRepository : IGameSessionRepository
    {
        private readonly GameDB _context;
        private readonly ILogger<GameSessionRepository> _logger;

        public GameSessionRepository(GameDB context, ILogger<GameSessionRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Get a game session by its Id
        public async Task<GameSession> GetGameSessionByIdAsync(int gameSessionId)
        {
            try
            {
                var gameSession = await _context.GameSessions
                    .Include(gs => gs.Game)
                    .Include(gs => gs.Player)
                    .FirstOrDefaultAsync(gs => gs.Id == gameSessionId);

                return gameSession;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Repository: Error in GetGameSessionByIdAsync: {msg}", ex.Message);
                throw;
            }
        }

        // Get all game sessions
        public async Task<IEnumerable<GameSession>> GetAllGameSessionsAsync()
        {
            try
            {
                var gameSessions = await _context.GameSessions
                    .Include(gs => gs.Game)
                    .Include(gs => gs.Player)
                    .ToListAsync();

                return gameSessions;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Repository: Error in GetAllGameSessionsAsync: {msg}", ex.Message);
                throw;
            }
        }

        // Add a new game session
        public async Task<GameSession> AddGameSessionAsync(GameSession gameSession)
        {
            try
            {
                if (gameSession == null)
                {
                    throw new ArgumentNullException(nameof(gameSession), "Try to add a new game session from an empty object");
                }

                await _context.GameSessions.AddAsync(gameSession);
                await _context.SaveChangesAsync();

                return gameSession;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Repository: Error in AddGameSessionAsync: {msg}", ex.Message);
                throw;
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning(ex, "Repository: Invalid input in AddGameSessionAsync: {msg}", ex.Message);
                throw;
            }
        }

        // Update an existing game session
        public async Task<GameSession> UpdateGameSessionAsync(GameSession updatedGameSession)
        {
            try
            {
                var existingGameSession = await _context.GameSessions
                    .FirstOrDefaultAsync(gs => gs.Id == updatedGameSession.Id);
                if (existingGameSession == null)
                {
                    return null;
                }

                existingGameSession.StartTime = updatedGameSession.StartTime;
                existingGameSession.EndTime = updatedGameSession.EndTime;
                existingGameSession.CorrectAnswers = updatedGameSession.CorrectAnswers;
                existingGameSession.IncorrectAnswers = updatedGameSession.IncorrectAnswers;

                await _context.SaveChangesAsync();
                return existingGameSession;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Repository: Error in UpdateGameSessionAsync: {msg}", ex.Message);
                throw;
            }
        }

        // Delete a game session by its Id
        public async Task<bool> DeleteGameSessionAsync(int gameSessionId)
        {
            try
            {
                var existingGameSession = await _context.GameSessions
                    .FirstOrDefaultAsync(gs => gs.Id == gameSessionId);
                if (existingGameSession == null)
                {
                    return false;
                }

                _context.GameSessions.Remove(existingGameSession);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Repository: Error in DeleteGameSessionAsync: {msg}", ex.Message);
                throw;
            }
        }
    }
}