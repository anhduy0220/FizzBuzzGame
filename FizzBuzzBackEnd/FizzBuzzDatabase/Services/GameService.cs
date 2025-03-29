using AutoMapper;
using FizzBuzzDatabase.Interfaces.IRepositories;
using FizzBuzzDatabase.DTOs;
using FizzBuzzDatabase.Interfaces.IServices;
using FizzBuzzDatabase.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzzDatabase.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameService(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<GameDto> CreateGameAsync(CreateGameDTO createGameDTO)
        {
            var game = _mapper.Map<Game>(createGameDTO);
            var createdGame = await _gameRepository.AddGameAsync(game);
            return _mapper.Map<GameDto>(createdGame);
        }

        public async Task<GameDto> GetGameByIdAsync(int id)
        {
            var game = await _gameRepository.GetGameByIdAsync(id);
            return _mapper.Map<GameDto>(game);
        }

        public async Task<IEnumerable<GameDto>> GetAllGamesAsync()
        {
            var games = await _gameRepository.GetAllGamesAsync();
            return _mapper.Map<IEnumerable<GameDto>>(games);
        }

        public async Task<GameDto> UpdateGameAsync(int id, UpdateGameDTO updateGameDTO)
        {
            var existingGame = await _gameRepository.GetGameByIdAsync(id);
            if (existingGame == null)
            {
                throw new KeyNotFoundException("Game not found");
            }

            _mapper.Map(updateGameDTO, existingGame);
            var updatedGame = await _gameRepository.UpdateGameAsync(existingGame);
            return _mapper.Map<GameDto>(updatedGame);
        }

        public async Task<bool> DeleteGameAsync(int id)
        {
            return await _gameRepository.DeleteGameAsync(id);
        }
    }
}
