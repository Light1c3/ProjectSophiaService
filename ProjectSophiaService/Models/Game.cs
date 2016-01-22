using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectSophiaService.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public string ImageUrl { get; set; }
    }
}