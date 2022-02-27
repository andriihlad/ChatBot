using System.ComponentModel.DataAnnotations;

namespace ChatBot.Models
{
    public class Map
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string City { get; set; }
    }
}
