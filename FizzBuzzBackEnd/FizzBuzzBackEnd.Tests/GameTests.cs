using FizzBuzzDatabase.Controllers;
using FizzBuzzDatabase.DTOs;
using FizzBuzzDatabase.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FizzBuzzDatabase.Tests
{
    public class GameControllerTests
    {
        private readonly GameController _controller;
        private readonly Mock<IGameService> _mockService;
        private readonly Mock<ILogger<GameController>> _mockLogger;

        public GameControllerTests()
        {
            _mockService = new Mock<IGameService>();
            _mockLogger = new Mock<ILogger<GameController>>();
            _controller = new GameController(_mockService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllGames_ReturnsGames()
        {
            // Arrange
            var games = new[] { new GameDto { Id = 1, Name = "Test" } };
            _mockService.Setup(x => x.GetAllGamesAsync()).ReturnsAsync(games);

            // Act
            var result = await _controller.GetAllGames();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(games, okResult.Value);
        }

        [Fact]
        public async Task CreateGame_ReturnsCreatedGame()
        {
            // Arrange
            var gameDto = new GameDto { Name = "New Game" };
            _mockService.Setup(x => x.CreateGameAsync(It.IsAny<GameDto>())).ReturnsAsync(gameDto);

            // Act
            var result = await _controller.CreateGame(gameDto);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(gameDto, createdResult.Value);
        }
    }
}