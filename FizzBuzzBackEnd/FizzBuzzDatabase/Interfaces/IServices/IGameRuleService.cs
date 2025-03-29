using FizzBuzzDatabase.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzzDatabase.Interfaces.IServices
{
    public interface IGameRuleService
    {
        // Create a new game rule
        public Task<GameRuleDto> CreateGameRuleAsync(CreateGameRuleDTO createGameRuleDTO);

        // Get a game rule by its ID
        public Task<GameRuleDto> GetGameRuleByIdAsync(int id);

        // Get all game rules for a specific game
        public Task<IEnumerable<GameRuleDto>> GetGameRulesByGameIdAsync(int gameId);

        // Update an existing game rule
        public Task<GameRuleDto> UpdateGameRuleAsync(int id, UpdateGameRuleDTO updateGameRuleDTO);

        // Delete a game rule by its ID
        public Task<bool> DeleteGameRuleAsync(int id);
    }
}