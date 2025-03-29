using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Models
{
    public class GameRule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Divisor { get; set; }

        [Required]
        public string Replacement { get; set; } = string.Empty;

        [ForeignKey("Game")]
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;
    }

}