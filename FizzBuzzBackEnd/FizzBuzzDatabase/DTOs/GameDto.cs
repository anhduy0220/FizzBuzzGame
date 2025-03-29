using FizzBuzzDatabase.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzzDatabase.DTOs
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; } // Unique game name (e.g., "FooBooLoo")
        public string Author { get; set; } // Creator of the game
        public List<GameRuleDto> Rules { get; set; } = new(); // List of rules for the game
    }
    public class CreateGameDTO
    {
        public string Name { get; set; } // Unique game name
        public string Author { get; set; } // Creator of the game
        public List<CreateGameRuleDTO> Rules { get; set; } = new(); // List of rules for the game
    }
    public class UpdateGameDTO
    {
        public string Name { get; set; } // Updated game name
        public string Author { get; set; } // Updated author name
        public List<UpdateGameRuleDTO> Rules { get; set; } = new(); // Updated list of rules
    }
}