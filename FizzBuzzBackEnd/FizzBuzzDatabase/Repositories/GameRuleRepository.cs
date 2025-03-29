using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FizzBuzzDatabase.Data;
using FizzBuzzDatabase.Interfaces.IRepositories;
using FizzBuzzDatabase.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzzDatabase.Server.Repositories
{
    public class GameRuleRepository : IGameRuleRepository
    {
        private readonly GameDB _context;
        private readonly ILogger<GameRuleRepository> _logger;

        public GameRuleRepository(GameDB context, ILogger<GameRuleRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Get a game rule by its Id
        public async Task<GameRule> GetGameRuleByIdAsync(int gameRuleId)
        {
            try
            {
                var gameRule = await _context.GameRules
                    .FirstOrDefaultAsync(gr => gr.Id == gameRuleId);

                return gameRule;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Repository: Error in GetGameRuleByIdAsync: {msg}", ex.Message);
                throw;
            }
        }

        // Get all game rules
        public async Task<IEnumerable<GameRule>> GetAllGameRulesAsync()
        {
            try
            {
                var gameRules = await _context.GameRules.ToListAsync();
                return gameRules;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Repository: Error in GetAllGameRulesAsync: {msg}", ex.Message);
                throw;
            }
        }

        // Add a new game rule
        public async Task<GameRule> AddGameRuleAsync(GameRule gameRule)
        {
            try
            {
                if (gameRule == null)
                {
                    throw new ArgumentNullException(nameof(gameRule), "Try to add a new game rule from an empty object");
                }

                await _context.GameRules.AddAsync(gameRule);
                await _context.SaveChangesAsync();

                return gameRule;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Repository: Error in AddGameRuleAsync: {msg}", ex.Message);
                throw;
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogWarning(ex, "Repository: Invalid input in AddGameRuleAsync: {msg}", ex.Message);
                throw;
            }
        }

        // Update an existing game rule
        public async Task<GameRule> UpdateGameRuleAsync(GameRule updatedGameRule)
        {
            try
            {
                var existingGameRule = await _context.GameRules
                    .FirstOrDefaultAsync(gr => gr.Id == updatedGameRule.Id);
                if (existingGameRule == null)
                {
                    return null;
                }

                existingGameRule.Divisor = updatedGameRule.Divisor;
                existingGameRule.Replacement = updatedGameRule.Replacement;

                await _context.SaveChangesAsync();
                return existingGameRule;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Repository: Error in UpdateGameRuleAsync: {msg}", ex.Message);
                throw;
            }
        }

        // Delete a game rule by its Id
        public async Task<bool> DeleteGameRuleAsync(int gameRuleId)
        {
            try
            {
                var existingGameRule = await _context.GameRules
                    .FirstOrDefaultAsync(gr => gr.Id == gameRuleId);
                if (existingGameRule == null)
                {
                    return false;
                }

                _context.GameRules.Remove(existingGameRule);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Repository: Error in DeleteGameRuleAsync: {msg}", ex.Message);
                throw;
            }
        }
    }
}
