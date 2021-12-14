using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyForumProject.Models
{
    public class Comment
    {
        public long Id { get; set; }
        [Required]
        public virtual AppUser User { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Content { get; set; }
        public virtual ICollection<CommentRate> Comments { get; set; }

    }


 
}
