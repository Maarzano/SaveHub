using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class SavedItems
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string? Url { get; set; }
        public string? Subreddit { get; set; }
        public DateTime? SavedAt { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}