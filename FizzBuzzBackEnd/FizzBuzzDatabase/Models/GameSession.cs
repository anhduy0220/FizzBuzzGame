namespace FizzBuzzDatabase.Models
{
    public class GameSession
    {
        public int Id { get; set; } // Primary key
        public int PlayerId { get; set; } // Foreign key for Player
        public Player Player { get; set; } // Navigation property for Player
        public int GameId { get; set; } // Foreign key for Game
        public Game Game { get; set; } // Navigation property for Game
        public int Score { get; set; } // Total score for the session
        public DateTime StartTime { get; set; } // When the session started
        public DateTime EndTime { get; set; } // When the session ended
        public int Duration { get; set; } // Duration of the session in seconds
        public int Questions { get; set; } // Number of questions asked
        public int CorrectAnswers { get; set; } // Number of correct answers
        public int IncorrectAnswers { get; set; } // Number of incorrect answers
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Record creation time
    }
}
