using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FizzBuzzDatabase.Models;

namespace FizzBuzzDatabase.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        public List<GameRule> Rules { get; set; } = new();
        public List<GameSession> GameSessions { get; set; } = new();
    }
}