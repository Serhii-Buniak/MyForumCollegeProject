using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyForumProject.Models
{
    public class PostRate

    {
        public long Id { get; set; }
        [Required]
        public virtual AppUser User { get; set; }
        [Required]
        public virtual Post Post { get; set; }
        public Rate Rate { get; set; } = Rate.None;

 

    }



}
