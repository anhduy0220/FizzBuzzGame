using System.ComponentModel.DataAnnotations;
using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Models
{
    public class GameSession
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;

        [Required]
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int Duration { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
    }

}