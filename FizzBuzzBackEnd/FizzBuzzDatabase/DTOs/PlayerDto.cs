using System.ComponentModel.DataAnnotations;

namespace FizzBuzzDatabase.DTOs
{
    public class PlayerDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<int> GameIds { get; set; } = new List<int>();
    }

}