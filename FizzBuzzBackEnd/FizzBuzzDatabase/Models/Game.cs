namespace FizzBuzzDatabase.Models
{
    public class Game
    {
        public int Id { get; set; } // Primary key
        public string GameName { get; set; } // Name of the game
        public string Author { get; set; } // Author of the game
        public int MinRange { get; set; } // Minimum range for random number generation
        public int MaxRange { get; set; } // Maximum range for random number generation
        public int Timer { get; set; } // Timer for the game
        public List<GameRule> Rules { get; set; } = new List<GameRule>(); // Navigation property for GameRules
    }
}
