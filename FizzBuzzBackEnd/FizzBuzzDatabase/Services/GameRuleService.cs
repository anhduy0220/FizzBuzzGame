using AutoMapper;
using FizzBuzzDatabase.Interfaces.IRepositories;
using FizzBuzzDatabase.DTOs;
using FizzBuzzDatabase.Interfaces.IServices;
using FizzBuzzDatabase.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzzDatabase.Services
{
    public class GameRuleService : IGameRuleService
    {
        private readonly IGameRuleRepository _gameRuleRepository;
        private readonly IMapper _mapper;

        public GameRuleService(IGameRuleRepository gameRuleRepository, IMapper mapper)
        {
            _gameRuleRepository = gameRuleRepository;
            _mapper = mapper;
        }

        public async Task<GameRuleDto> CreateGameRuleAsync(CreateGameRuleDTO createGameRuleDTO)
        {
            var gameRule = _mapper.Map<GameRule>(createGameRuleDTO);
            var createdGameRule = await _gameRuleRepository.AddGameRuleAsync(gameRule);
            return _mapper.Map<GameRuleDto>(createdGameRule);
        }

        public async Task<GameRuleDto> GetGameRuleByIdAsync(int id)
        {
            var gameRule = await _gameRuleRepository.GetGameRuleByIdAsync(id);
            return _mapper.Map<GameRuleDto>(gameRule);
        }

        public async Task<IEnumerable<GameRuleDto>> GetGameRulesByGameIdAsync(int gameId)
        {
            var gameRules = await _gameRuleRepository.GetAllGameRulesAsync();
            return _mapper.Map<IEnumerable<GameRuleDto>>(gameRules);
        }

        public async Task<GameRuleDto> UpdateGameRuleAsync(int id, UpdateGameRuleDTO updateGameRuleDTO)
        {
            var existingGameRule = await _gameRuleRepository.GetGameRuleByIdAsync(id);
            if (existingGameRule == null)
            {
                throw new KeyNotFoundException("GameRule not found");
            }

            _mapper.Map(updateGameRuleDTO, existingGameRule);
            var updatedGameRule = await _gameRuleRepository.UpdateGameRuleAsync(existingGameRule);
            return _mapper.Map<GameRuleDto>(updatedGameRule);
        }

        public async Task<bool> DeleteGameRuleAsync(int id)
        {
            return await _gameRuleRepository.DeleteGameRuleAsync(id);
        }
    }
}