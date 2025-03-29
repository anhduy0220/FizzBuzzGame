namespace FizzBuzzDatabase.DTOs
{
    public class GameRuleDto
    {
        public int Id { get; set; }
        public int Divisor { get; set; } // Divisor for the rule (e.g., 7 for "Foo")
        public string Replacement { get; set; } // Word to replace (e.g., "Foo")
        public int GameId { get; set; } // ID of the game this rule belongs to
    }
    public class CreateGameRuleDTO
    {
        public int Divisor { get; set; } // Divisor for the rule
        public string Replacement { get; set; } // Word to replace
        public int GameId { get; set; } // ID of the game this rule belongs to
    }
    public class UpdateGameRuleDTO
    {
        public int Divisor { get; set; } // Updated divisor
        public string Replacement { get; set; } // Updated replacement word
    }

}