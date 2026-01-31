using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public bool Offer { get; set; }
        [MaxLength(250)]
        public string? Title { get; set; }
        [MaxLength(250)] 
        public string? Image { get; set; } 
    }
}
