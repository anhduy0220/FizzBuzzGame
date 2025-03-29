using System.ComponentModel.DataAnnotations;
using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<GameSession> GameSessions { get; set; } = new();
    }

}