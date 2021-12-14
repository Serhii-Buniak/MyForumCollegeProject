using System;
using System.ComponentModel.DataAnnotations;

namespace MyForumProject.Models
{
    public class CommentNotification
    {
        public long Id { get; set; }
        [Required]
        public virtual AppUser User { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime DateTime { get; set; } = DateTime.Now;

    }


 
}
