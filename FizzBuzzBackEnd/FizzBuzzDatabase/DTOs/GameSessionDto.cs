namespace FizzBuzzDatabase.DTOs
{
    public class GameSessionDto
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
    }
    public class InitialGameSessionDTO
    {
        public int GameId { get; set; } // ID of the game being played
        public int PlayerId { get; set; } // ID of the player
        public int DurationInSeconds { get; set; } // Duration of the game session in seconds
    }
    public class InitialGameSessionQuestionDTO
    {
        public int GameSessionId { get; set; } // ID of the newly created game session
        public int Number { get; set; } // The first random number to display
    }
    public class GameSessionAnswerDTO
    {
        public int GameSessionId { get; set; } // ID of the game session
        public int Number { get; set; } // The number that was displayed
        public string PlayerAnswer { get; set; } // The player's answer
    }
    public class GameSessionResultAndNewQuestionDTO
    {
        public bool IsCorrect { get; set; } // Whether the player's answer was correct
        public int NextNumber { get; set; } // The next random number to display
    }
    public class GameSessionResultDTO
    {
        public int GameSessionId { get; set; } // ID of the game session
        public int CorrectAnswers { get; set; } // Total correct answers
        public int IncorrectAnswers { get; set; } // Total incorrect answers
        public int TotalQuestions { get; set; } // Total questions asked
    }
}