namespace FizzBuzzDatabase.Models
{
    public class GameRule
    {
        public int Id { get; set; } // Primary key
        public int GameId { get; set; } // Foreign key for Game
        public Game Game { get; set; } // Navigation property for Game
        public int Divisor { get; set; } // Divisor for the rule
        public string Word { get; set; } // Replacement word for the rule
    }
}
