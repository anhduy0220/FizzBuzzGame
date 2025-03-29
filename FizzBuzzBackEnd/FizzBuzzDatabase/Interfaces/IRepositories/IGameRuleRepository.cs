using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Interfaces.IRepositories
{
    public interface IGameRuleRepository
    {
        Task<GameRule> GetGameRuleByIdAsync(int gameRuleId);
        Task<IEnumerable<GameRule>> GetAllGameRulesAsync();
        Task<GameRule> AddGameRuleAsync(GameRule gameRule);
        Task<GameRule> UpdateGameRuleAsync(GameRule gameRule);
        Task<bool> DeleteGameRuleAsync(int gameRuleId);
    }
}