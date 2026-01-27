using Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Experience
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string? Title { get; set; }
        [MaxLength(250)]
        public string? JobStyle { get; set; }
        [MaxLength(250)]
        public string? Company { get; set; }
        [MaxLength(250)]
        public string? Image { get; set; }
        [MaxLength(250)]
        public string? Url { get; set; }
        [MaxLength(750)]
        public string? Text { get; set; }
        [MaxLength(250)]
        public string? Tags { get; set; }
        [MaxLength(350)]
        public string? ShortText { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public ExperienceType ExperienceType { get; set; }
    }
}
