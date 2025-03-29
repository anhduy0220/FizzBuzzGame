using FizzBuzzDatabase.Controllers;
using FizzBuzzDatabase.DTOs;
using FizzBuzzDatabase.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FizzBuzzDatabase.Tests
{
    public class GameSessionControllerTests
    {
        private readonly GameSessionController _controller;
        private readonly Mock<IGameSessionService> _mockService;
        private readonly Mock<ILogger<GameSessionController>> _mockLogger;

        public GameSessionControllerTests()
        {
            _mockService = new Mock<IGameSessionService>();
            _mockLogger = new Mock<ILogger<GameSessionController>>();
            _controller = new GameSessionController(_mockService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task StartSession_ReturnsInitialQuestion()
        {
            // Arrange
            var dto = new InitialGameSessionDTO { GameId = 1, PlayerId = 1, DurationInSeconds = 60 };
            var expected = new InitialGameSessionQuestionDTO { GameSessionId = 1, Number = 15 };

            _mockService.Setup(x => x.CreateAndStartGameSessionAsync(dto)).ReturnsAsync(expected);

            // Act
            var result = await _controller.CreateAndStartGameSession(dto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expected, okResult.Value);
        }

        [Fact]
        public async Task SubmitAnswer_ReturnsNextQuestion()
        {
            // Arrange
            var dto = new GameSessionAnswerDTO { GameSessionId = 1, Number = 15, PlayerAnswer = "Fizz" };
            var expected = new GameSessionResultAndNewQuestionDTO { IsCorrect = true, NextNumber = 20 };

            _mockService.Setup(x => x.HandleGameSessionAnswerAsync(dto)).ReturnsAsync(expected);

            // Act
            var result = await _controller.HandleGameSessionAnswer(dto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expected, okResult.Value);
        }
    }
}