using FizzBuzzDatabase.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzzDatabase.Interfaces.IServices
{
    public interface IGameService
    {
        // Create a new game
        public Task<GameDto> CreateGameAsync(CreateGameDTO createGameDTO);

        // Get a game by its ID
        public Task<GameDto> GetGameByIdAsync(int id);

        // Get all games
        public Task<IEnumerable<GameDto>> GetAllGamesAsync();

        // Update an existing game
        public Task<GameDto> UpdateGameAsync(int id, UpdateGameDTO updateGameDTO);

        // Delete a game by its ID
        public Task<bool> DeleteGameAsync(int id);
    }
}