using System.ComponentModel.DataAnnotations;

namespace ChatAPI.Models
{
    public class MessageDTO
    {
        [Required]
        public string From { get; set; }
        public string To { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
