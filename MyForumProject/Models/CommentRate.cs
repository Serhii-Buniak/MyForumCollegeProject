using System.ComponentModel.DataAnnotations;

namespace MyForumProject.Models
{
    public class CommentRate
    {
        public long Id { get; set; }
        [Required]
        public virtual AppUser User { get; set; }
        [Required]
        public virtual Comment Comment { get; set; }
        public Rate Rate { get; set; } = Rate.None;

    }


 
}
