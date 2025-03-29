using AutoMapper;
using FizzBuzzDatabase.Interfaces.IRepositories;
using FizzBuzzDatabase.DTOs;
using FizzBuzzDatabase.Interfaces.IServices;
using FizzBuzzDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzzDatabase.Services
{
    public class GameSessionService : IGameSessionService
    {
        private readonly IGameSessionRepository _gameSessionRepository;
        private readonly IMapper _mapper;
        private readonly Random _random = new Random();
        private readonly HashSet<int> _usedNumbers = new HashSet<int>();

        public GameSessionService(IGameSessionRepository gameSessionRepository, IMapper mapper)
        {
            _gameSessionRepository = gameSessionRepository;
            _mapper = mapper;
        }

        public async Task<InitialGameSessionQuestionDTO> CreateAndStartGameSessionAsync(InitialGameSessionDTO initialGameSessionDTO)
        {
            var gameSession = _mapper.Map<GameSession>(initialGameSessionDTO);
            gameSession.StartTime = DateTime.UtcNow;

            var createdGameSession = await _gameSessionRepository.AddGameSessionAsync(gameSession);

            // Generate the first random number
            int firstNumber = GenerateRandomNumber();
            _usedNumbers.Add(firstNumber);

            return new InitialGameSessionQuestionDTO
            {
                GameSessionId = createdGameSession.Id,
                Number = firstNumber
            };
        }

        public async Task<GameSessionResultAndNewQuestionDTO> HandleGameSessionAnswerAsync(GameSessionAnswerDTO gameSessionAnswerDTO)
        {
            var gameSession = await _gameSessionRepository.GetGameSessionByIdAsync(gameSessionAnswerDTO.GameSessionId);
            if (gameSession == null)
            {
                throw new KeyNotFoundException("GameSession not found");
            }

            // Validate the player's answer
            bool isCorrect = ValidateAnswer(gameSessionAnswerDTO.Number, gameSessionAnswerDTO.PlayerAnswer);

            // Update the game session with the result
            if (isCorrect)
            {
                gameSession.CorrectAnswers++;
            }
            else
            {
                gameSession.IncorrectAnswers++;
            }

            await _gameSessionRepository.UpdateGameSessionAsync(gameSession);

            // Generate the next random number
            int nextNumber = GenerateRandomNumber();
            _usedNumbers.Add(nextNumber);

            return new GameSessionResultAndNewQuestionDTO
            {
                IsCorrect = isCorrect,
                NextNumber = nextNumber
            };
        }

        public async Task<GameSessionResultDTO> FinalizeGameSessionAsync(int gameSessionId)
        {
            var gameSession = await _gameSessionRepository.GetGameSessionByIdAsync(gameSessionId);
            if (gameSession == null)
            {
                throw new KeyNotFoundException("GameSession not found");
            }

            // Set the end time of the game session
            gameSession.EndTime = DateTime.UtcNow;
            await _gameSessionRepository.UpdateGameSessionAsync(gameSession);

            return new GameSessionResultDTO
            {
                GameSessionId = gameSession.Id,
                CorrectAnswers = gameSession.CorrectAnswers,
                IncorrectAnswers = gameSession.IncorrectAnswers,
                TotalQuestions = gameSession.CorrectAnswers + gameSession.IncorrectAnswers
            };
        }

        public async Task<GameSessionResultDTO> GetGameSessionResultAsync(int gameSessionId)
        {
            var gameSession = await _gameSessionRepository.GetGameSessionByIdAsync(gameSessionId);
            if (gameSession == null)
            {
                throw new KeyNotFoundException("GameSession not found");
            }

            return new GameSessionResultDTO
            {
                GameSessionId = gameSession.Id,
                CorrectAnswers = gameSession.CorrectAnswers,
                IncorrectAnswers = gameSession.IncorrectAnswers,
                TotalQuestions = gameSession.CorrectAnswers + gameSession.IncorrectAnswers
            };
        }

        private int GenerateRandomNumber()
        {
            int number;
            do
            {
                // Generate a random number divisible by 7, 13, or 103
                number = _random.Next(1, 1000) * 7; // Example: Ensure divisibility by 7
            } while (_usedNumbers.Contains(number));

            return number;
        }

        private bool ValidateAnswer(int number, string playerAnswer)
        {
            // Replace this with your actual validation logic
            // Example: Check if the player's answer matches the expected replacement word
            if (number % 7 == 0 && playerAnswer == "Foo")
            {
                return true;
            }
            if (number % 13 == 0 && playerAnswer == "Boo")
            {
                return true;
            }
            if (number % 103 == 0 && playerAnswer == "Loo")
            {
                return true;
            }
            return false;
        }
    }
}