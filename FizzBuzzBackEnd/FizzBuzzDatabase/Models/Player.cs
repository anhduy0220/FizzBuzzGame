namespace FizzBuzzDatabase.Models
{
    public class Player
    {
        public int Id { get; set; } // Primary key
        public string Name { get; set; } // Player's name
        public string Email { get; set; } // Player's email
        public int HighScore { get; set; } // Highest score achieved
        public List<GameSession> GameSessions { get; set; } = new List<GameSession>(); // Relationship with GameSession
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Date when the player was added
        public bool IsActive { get; set; } = true; // Indicates if the player is active
    }
}
