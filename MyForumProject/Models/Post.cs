using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MyForumProject.Models
{
    public class Post
    {
        public long Id { get; set; }
        [Required]
        public virtual AppUser User { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostRate> Rates { get; set; }

    }


 
}
