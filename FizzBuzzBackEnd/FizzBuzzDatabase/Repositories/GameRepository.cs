using FizzBuzzDatabase.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FizzBuzzDatabase.Data;
using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Server.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameDB _context;
        private readonly ILogger<GameRepository> _logger;

        public GameRepository(GameDB context, ILogger<GameRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Get a game by its Id
        public async Task<Game> GetGameByIdAsync(int gameId)
        {
            try
            {
                var game = await _context.Games
                    .Include(g => g.Rules) // Including rules if necessary
                    .FirstOrDefaultAsync(g => g.Id == gameId);

                return game;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Repository: Error in GetGameByIdAsync: {msg}", ex.Message);
                throw;
            }
        }

        // Get all games
        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            try
            {
                var games = await _context.Games
                    .Include(g => g.Rules) // Including rules if necessary
                    .ToListAsync();

                return games;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Repository: Error in GetAllGamesAsync: {msg}", ex.Message);
                throw;
            }
        }
        public async Task<Game> AddGameAsync(Game game)
        {
            try
            {
                if (game == null)
                {
                    throw new ArgumentNullException(nameof(game), "Try to add a new game from an empty object");
                }

                await _context.Games.AddAsync(game);
                await _context.SaveChangesAsync();

                return game;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Repository: Error in AddGameAsync: {msg}", ex.Message);
                throw;
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning(ex, "Repository: Invalid input in AddGameAsync: {msg}", ex.Message);
                throw;
            }
        }

        public async Task<Game> UpdateGameAsync(Game updatedGame)
        {
            try
            {
                var existingGame = await _context.Games
                    .FirstOrDefaultAsync(g => g.Id == updatedGame.Id);
                if (existingGame == null)
                {
                    return null;
                }

                existingGame.Name = updatedGame.Name;
                existingGame.Author = updatedGame.Author;

                await _context.SaveChangesAsync();
                return existingGame;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Repository: Error in UpdateGameAsync: {msg}", ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteGameAsync(int gameId)
        {
            try
            {
                var existingGame = await _context.Games
                    .FirstOrDefaultAsync(g => g.Id == gameId);
                if (existingGame == null)
                {
                    return false;
                }

                _context.Games.Remove(existingGame);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Repository: Error in DeleteGameAsync: {msg}", ex.Message);
                throw;
            }
        }
    }
}
