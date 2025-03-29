using FizzBuzzDatabase.Controllers;
using FizzBuzzDatabase.DTOs;
using FizzBuzzDatabase.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FizzBuzzDatabase.Tests
{
    public class GameRuleControllerTests
    {
        private readonly GameRuleController _controller;
        private readonly Mock<IGameRuleService> _mockService;
        private readonly Mock<ILogger<GameRuleController>> _mockLogger;

        public GameRuleControllerTests()
        {
            _mockService = new Mock<IGameRuleService>();
            _mockLogger = new Mock<ILogger<GameRuleController>>();
            _controller = new GameRuleController(_mockService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task CreateGameRule_ReturnsCreatedRule()
        {
            // Arrange
            var ruleDto = new GameRuleDto { GameId = 1, Divisor = 3, Replacement = "Fizz" };
            _mockService.Setup(x => x.CreateGameRuleAsync(ruleDto)).ReturnsAsync(ruleDto);

            // Act
            var result = await _controller.CreateGameRule(ruleDto);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(ruleDto, createdResult.Value);
        }

        [Fact]
        public async Task GetRulesByGameId_ReturnsRules()
        {
            // Arrange
            var rules = new[] { new GameRuleDto { GameId = 1, Divisor = 3, Replacement = "Fizz" } };
            _mockService.Setup(x => x.GetGameRulesByGameIdAsync(1)).ReturnsAsync(rules);

            // Act
            var result = await _controller.GetGameRulesByGameId(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(rules, okResult.Value);
        }
    }
}